using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPP.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace NewsAPP.Controllers   
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            List<User> mylist = new List<User>();
            client.BaseAddress = new Uri("https://localhost:7024/");
            HttpResponseMessage responce = await client.GetAsync("api/News/get_users");

            if (responce.IsSuccessStatusCode)
            {
                var result = responce.Content.ReadAsStringAsync().Result;
                List<User>? news = JsonConvert.DeserializeObject<List<User>>(result);
                mylist = news;
            }
            return View(mylist);
        }


        /*[HttpDelete]
        [Route("User/{id}")]*/

        /*async Task<ActionResult> DeleteUser(int id)
        {
            *//*string id = Request.Query["id"];*//*
            UserId userId = new UserId();
            userId.user_id = id;

            List<DeleteUserResponse> mylist = new List<DeleteUserResponse>();
            HttpResponseMessage responce = await PostJsonAsync("https://localhost:7024/api/News/DeleteUser/" + userId.user_id, userId.user_id);
            if (responce.IsSuccessStatusCode)
            {
                var result = responce.Content.ReadAsStringAsync().Result;
                List<DeleteUserResponse>? news = JsonConvert.DeserializeObject<List<DeleteUserResponse>>(result);
                mylist = news;
            }
            return View(mylist);
            *//*return RedirectToAction("Index", "User");*//*
        }

        static Task<HttpResponseMessage> PostJsonAsync(string url, object body)
        {
            HttpClient client = new HttpClient();
            var bodyJson = System.Text.Json.JsonSerializer.Serialize(body);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            return client.PostAsync(url, stringContent);
        }

        [HttpGet]
        public async Task<IActionResult> User()
        {
            List<DeleteUserResponse> mylist = new List<DeleteUserResponse>();
            return View(mylist);
        }*/

        public async Task<IActionResult> DeleteUser(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            HttpResponseMessage responce = await client.GetAsync("api/News/DeleteUser/" + id);

            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Index", "User");

        }

    }



    
}


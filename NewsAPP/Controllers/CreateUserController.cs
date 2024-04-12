using Microsoft.AspNetCore.Mvc;
using NewsAPP.Models;
using NewsWebAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewsAPP.Controllers
{
    public class CreateUserController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index(AddUser adduser)
        {
            List<AddUserResponse> mylist = new List<AddUserResponse>();
            HttpResponseMessage responce = await PostJsonAsync("https://localhost:7024/api/News/AddUser", adduser);
            if (responce.IsSuccessStatusCode)
            {
                var result = responce.Content.ReadAsStringAsync().Result;
                List<AddUserResponse>? news = JsonConvert.DeserializeObject<List<AddUserResponse>>(result);
                mylist = news;
            }
            return View(mylist);
        }

        public static Task<HttpResponseMessage> PostJsonAsync(string url, object body)
        {
            HttpClient client = new HttpClient();
            var bodyJson = System.Text.Json.JsonSerializer.Serialize(body);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            return client.PostAsync(url, stringContent);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<AddUserResponse> mylist = new List<AddUserResponse>();
            return View(mylist);
        }
    }
}

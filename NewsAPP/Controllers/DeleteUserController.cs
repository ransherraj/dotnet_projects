/*using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NewsWebAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewsAPP.Controllers
{
    public class DeleteUserController : Controller
    {

        public DeleteUserController()
        {
            [HttpDelete]
            async Task<ActionResult> Index(UserId userId)
            {
                List<AddUserResponse> mylist = new List<AddUserResponse>();
                HttpResponseMessage responce = await PostJsonAsync("https://localhost:7024/api/News/DeleteUser/" + userId.user_id, userId.user_id);
                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;
                    List<AddUserResponse>? news = JsonConvert.DeserializeObject<List<AddUserResponse>>(result);
                    mylist = news;
                }
                return View(mylist);
            }

            static Task<HttpResponseMessage> PostJsonAsync(string url, object body)
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


        public IActionResult Index()
        {
            return View();
        }
    }
}


*/


using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPP.Models;
using NewsWebAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewsAPP.Controllers
{
    public class DeleteUserController : Controller
    {

        public async Task<IActionResult> DeleteUser(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            HttpResponseMessage responce = await client.DeleteAsync("api/News/DeleteUser/" + id);

            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Index", "User");

        }

    }
}

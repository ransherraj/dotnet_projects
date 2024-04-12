using Microsoft.AspNetCore.Mvc;
using NewsAPP.Models;
using Newtonsoft.Json;
using System.Text;

namespace NewsAPP.Controllers
{
    public class EditUserController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> EditUser(int id)
        {
            AddUser userInfo = new AddUser();


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7024/");
            HttpResponseMessage responce = await client.GetAsync("api/News/GetUserById/" + id);

            if (responce.IsSuccessStatusCode)
            {
                var result = responce.Content.ReadAsStringAsync().Result;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                userInfo = JsonConvert.DeserializeObject<AddUser>(result);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            return View(userInfo);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(AddUser emp)
        {
            var bodyJson = System.Text.Json.JsonSerializer.Serialize(emp);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage responce = await client.PostAsync("https://localhost:7024/api/News/EditUser", stringContent);
            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }

            return View();
        }


    }
}

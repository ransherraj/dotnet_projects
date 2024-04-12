using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NewsAPP.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Text.Json;

namespace NewsAPP.Controllers
{
    public class NewsController : Controller
    {
        
        //string UserId = Request.Form["user_id"];
        [HttpPost]
        public async Task<IActionResult> Index(UserId userId)
        {
            
            List<NewsDetail> mylist = new List<NewsDetail>();
            
            
            HttpResponseMessage responce = await PostJsonAsync("https://localhost:7024/api/News/get_news", userId);

            if (responce.IsSuccessStatusCode)
            {
                
                var result = responce.Content.ReadAsStringAsync().Result;
                List<NewsDetail>? news = JsonConvert.DeserializeObject<List<NewsDetail>>(result);
                mylist = news;

            }

            return View(mylist);
        }

        
        public static  Task<HttpResponseMessage> PostJsonAsync( string url, object body) 
        {
            HttpClient client = new HttpClient();
            var bodyJson = System.Text.Json.JsonSerializer.Serialize(body);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            return  client.PostAsync(url, stringContent);
        }



        [HttpGet]
        /* public async IActionResult Index()*/
        public async Task<IActionResult> Index()
        {
             List<NewsDetail> mylist = new List<NewsDetail>();
            return View(mylist);

        }


    }
}

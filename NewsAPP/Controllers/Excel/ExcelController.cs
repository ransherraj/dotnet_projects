using Microsoft.AspNetCore.Mvc;

namespace NewsAPP.Controllers.Excel
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ImportExcelFile()
        {
            return View();
        }


    }
}

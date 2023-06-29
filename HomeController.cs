using crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DBConnPresent DBobj = new DBConnPresent();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string stringBuilder = "";
            string msg = "no";
            string fjh = "ksfufelyduefdjudweewiuip";
            string find = "kuldeep";
            for(int i=0;i<find.Length;i++)
            {
                for(int j=0;j<fjh.Length;j++)
                {
                    if (fjh[j]==find[i])
                    {
                        stringBuilder+=find[i].ToString();
                        break;
                    }
                    else if(stringBuilder=="kuldeep")
                    {
                        msg="yes";
                    }
                   
                }
            }
            var data= DBobj.GetAllStudents();
            return View(data);
        }
        [HttpGet]
        public IActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert(employee emp)
        {
           bool data= DBobj.InsertVAlue(emp);
            if (data==true)
            {
                return RedirectToAction("Index");
            }
            else
            { return View("Not Delete Page"); }
        }
        [HttpGet]
        public IActionResult update(int id)
        {
            var findRecord = DBobj.GetAllStudents().Find(x => x.ID==id);
            return View(findRecord);
        }
        [HttpPost]
        public IActionResult update(employee emp)
        {
           var data= DBobj.UpdateEmployeeRecord(emp);
            if (data==true)
            {
                return RedirectToAction("Index");
            }
            else
            { return View("Not Delete Page"); }
        }  
        [HttpGet]
        public IActionResult Delete(int id)
        {
           bool data= DBobj.Delete(id);
            if(data==true)
            {
            return RedirectToAction("Index");
            }
            else
            { return View("Not Delete Page"); }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
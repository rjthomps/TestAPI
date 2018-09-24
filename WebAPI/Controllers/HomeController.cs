using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private DataModel data;

        public HomeController(DataModel data)
        {
            this.data = data;
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
 


            //List<Models.Product> prods = data.Products.ToList();


            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

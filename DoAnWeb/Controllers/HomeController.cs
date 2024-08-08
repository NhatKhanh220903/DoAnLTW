using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb.Models;
namespace DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult XeMay8xemay()
        {
            var list = db.XEMAYs.Take(8).ToList();
            return View(list);
        }
    }
}
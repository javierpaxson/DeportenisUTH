using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;
using DeportenisUTH.Models;
using Database;

namespace DeportenisUTH.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Edit(API.Models.Category model)
        {
            API.Catalogs.Category api = new API.Catalogs.Category();           
            int result = 0;
            model.LastUpdated = DateTime.Now;
            model.LastCreated = DateTime.Now;
            result = api.Add(model);
            return View();
        }
        public ActionResult Create()
        {
            //DeportenisUTH.Models.Category model = new DeportenisUTH.Models.Category();
            API.Models.Category model = new API.Models.Category();

            return View("_Edit",model);
        }
    }
}
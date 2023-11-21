using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;
using Database;

namespace DeportenisUTH.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            User model = new User();
            int result = 0;
            API.Catalogs.Users api = new API.Catalogs.Users();
            model.Name = "Javier";
            model.LastName = "Marin";
            model.Email = "jh@email.com";
            model.Password = "12345";
            model.Rol = "Cliente";
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);
            return View();
        }
    }
}
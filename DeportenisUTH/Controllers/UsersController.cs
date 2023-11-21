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

            API.Catalogs.Users api = new API.Catalogs.Users();
            model.Name = "name";
            model.LastName = "asd";
            model.Email = "email";
            model.Password = "password";
            model.Rol = "admin";
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);
            return View();
        }
    }
}
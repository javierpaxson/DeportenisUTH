using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Database;
using API.Catalogs;
using API.Models;
using System.Data.Entity.Validation;
using API.Models;
using System.Data.Entity.Migrations.Model;
namespace Tests
{
    [TestClass]
    public class Orders
    {
        API.Models.Orders model = new API.Models.Orders();
        DeportenisEntities entity = new DeportenisEntities();

        [TestMethod]
        public void AddOrder()
        {
            int result = 0;
            API.Catalogs.Orders api = new API.Catalogs.Orders();

            model.UserID = 3;
            model.City = "UTH";
            model.Address = "PAUL";
            model.Cost = 122;
            model.Status = "Yes";
            model.Date = DateTime.Now;
            model.Hour = string.Empty;
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);

            Assert.AreNotEqual(result, -1);
        }
        [TestMethod]
        public void DeleteOrders()
        {
            int result = 0;
            API.Catalogs.Orders api = new API.Catalogs.Orders();
            result = api.Delete(2);
            Assert.AreNotEqual(result, -1);


        }
        [TestMethod]
        public void FindOrders()
        {
            string name = string.Empty;

            API.Catalogs.Orders api = new API.Catalogs.Orders();
            Database.Order model2 = new Database.Order();
            model2 = api.Find(1);
            if (model2 != null)
            {
                name = model2.City;
            }
            Assert.IsNotNull(model2);
        }
        [TestMethod]
        public void UpdateOrders()
        {
            int result = 0;
            API.Catalogs.Orders api = new API.Catalogs.Orders();
            //API.Models.Category model2 = new API.Models.Category();


            model.Id = 1;
           // model.Name = "Jordan";
            model.UserID = 1;
            model.City = "Hermosillo";
            model.Address = "Agavez";
            model.Cost = 100;
            model.Status = "NO";
            model.Date = DateTime.Now;
            model.Hour = "Mexico.jpg";
            model.LastUpdated = DateTime.Now;
            result = api.Update(model);

            Assert.AreNotEqual(result, -1);
        }
    }
}

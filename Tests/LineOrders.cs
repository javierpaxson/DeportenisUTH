using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Database;
using API.Catalogs;
using API.Models;
using System.Data.Entity.Validation;
using API.Models;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Infrastructure;

namespace Tests
{
    [TestClass]
    public class LineOrders
    {
        API.Models.LineOrders model = new API.Models.LineOrders();
        DeportenisEntities entity = new DeportenisEntities();

        [TestMethod]
        public void AddLineOrders()
        {
            int result = 0;
            API.Catalogs.LineOrders api = new API.Catalogs.LineOrders();
            
            model.OrderID = 3;
            model.ProductID = 8;
            model.Units = 10;            
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);

            Assert.AreNotEqual(result, -1);
        }
        [TestMethod]
        public void DeleteLineOrder()
        {
            int result = 0;
            API.Catalogs.LineOrders api = new API.Catalogs.LineOrders();
            result = api.Delete(3);
            Assert.AreNotEqual(result, -1);


        }
        [TestMethod]
        public void FindLineOrders()
        {
            string name = string.Empty;
            int id = 0;

            API.Catalogs.LineOrders api = new API.Catalogs.LineOrders();
            Database.LineOrder model2 = new Database.LineOrder();
            model2 = api.Find(2);
            if (model2 != null)
            {
                //name = model2.Name;
                id = model2.Id;
            }
            Assert.IsNotNull(model2);
        }
        [TestMethod]
        public void UpdateProduct()
        {
            int result = 0;
            API.Catalogs.LineOrders api = new API.Catalogs.LineOrders();
           // API.Models.Category model2 = new API.Models.Category();


            model.Id = 2;
            model.OrderID = 1;
            model.ProductID  = 6;
            model.Units = 15;
            model.LastUpdated = DateTime.Now;
            result = api.Update(model);

            Assert.AreNotEqual(result, -1);
        }
    }
}

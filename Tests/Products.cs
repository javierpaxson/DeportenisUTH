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
    public class Products
    {
        API.Models.Products model = new API.Models.Products();
        DeportenisEntities entity = new DeportenisEntities();

        [TestMethod]
        public void AddProduct()
        {
            int result = 0;
            API.Catalogs.Products api = new API.Catalogs.Products();
            
            model.CategoryID = 1;
            model.Name = "Puma";
            model.Description = "asdasd";
            model.Price = 122 ;
            model.Stock = 3;
            model.SaleOff = 0;
            model.Date = DateTime.Now;
            model.Image = string.Empty; 
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);

            Assert.AreNotEqual(result, -1);
        }
        [TestMethod]
        public void DeleteProduct()
        {
            int result = 0;
            API.Catalogs.Products api = new API.Catalogs.Products();
            result = api.Delete(9);
            Assert.AreNotEqual(result, -1);


        }
        [TestMethod]
        public void FindProduct()
        {
            string name = string.Empty;

            API.Catalogs.Products api = new API.Catalogs.Products();
            Database.Product model2 = new Database.Product();
            model2 = api.Find(6);
            if (model2 != null)
            {
                name = model2.Name;
            }
            Assert.IsNotNull(model2);
        }
        [TestMethod]
        public void UpdateProduct()
        {
            int result = 0;
            API.Catalogs.Products api = new API.Catalogs.Products();
            //API.Models.Category model2 = new API.Models.Category();


            model.Id = 6;
            //model.Name = "Jordan";
            model.CategoryID = 3;
            model.Name = "Futbol";
            model.Description = "Nike";
            model.Price = 100;
            model.Stock = 80;
            model.SaleOff = 10;
            model.Date = DateTime.Now;
            model.Image = "Balon.jpg";
            model.LastUpdated = DateTime.Now;
            result = api.Update(model);

            Assert.AreNotEqual(result, -1);
        }
    }
}

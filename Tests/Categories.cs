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
    public class Categorie
    {
        API.Models.Category model = new API.Models.Category();
        DeportenisEntities entity = new DeportenisEntities();

        [TestMethod]
        public void AddCategories()
        {
            int result = 0;
            API.Catalogs.Category api = new API.Catalogs.Category();
            model.Name = "Balones";
            
            model.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.Add(model);

            Assert.AreNotEqual(result, -1);
        }
        [TestMethod]
        public void DeleteCategory()
        {
            int result = 0;
            API.Catalogs.Category api = new API.Catalogs.Category();
            result = api.Delete(2);
            Assert.AreNotEqual(result, -1);


        }
        [TestMethod]
        public void FindCategories()
        {
            string name = string.Empty;

            API.Catalogs.Category api = new API.Catalogs.Category();
            Database.Category model2 = new Database.Category();
            model2 = api.Find(1);
            if (model2 != null)
            {
                name = model2.Name;
            }
            Assert.IsNotNull(model2);
        }
        [TestMethod]
        public void UpdateCategory()
        {
            int result = 0;
            API.Catalogs.Category api = new API.Catalogs.Category();
            //API.Models.Category model2 = new API.Models.Category();


            model.Id = 1;
            model.Name = "Jordan";
      
            //model2.LastCreated = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            result = api.UpdateCategory(model);

            Assert.AreNotEqual(result, -1);
        }
    }
}

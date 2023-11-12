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
    public class Categories
    {
        API.Models.Category model = new API.Models.Category();
        DeportenisEntities entity = new DeportenisEntities();

        [TestMethod]
        public void AddCategories()
        {
            int result = 0;
            API.Catalogs.Category api = new API.Catalogs.Category();
            model.Name = "Tenis";
            
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
        //    [TestMethod]
        //    public void FindUsers()
        //    {
        //        string name = string.Empty;
        //        string lastName = string.Empty;

        //        API.Catalogs.Users api = new API.Catalogs.Users();
        //        model = api.Find(1);
        //        if(model != null)
        //        {
        //            name = model.Name;
        //            lastName = model.LastName;
        //        }
        //        Assert.IsNotNull(model);
        //    }
        //    [TestMethod]
        //    public void UpdateUsers()
        //    {
        //        int result = 0;
        //        API.Catalogs.Users api = new API.Catalogs.Users();
        //        API.Models.Users model2 = new API.Models.Users();


        //        model2.Id = 1;
        //        model2.Name = "Jesus Paul";
        //        model2.LastName = "Marin Moreno";
        //        model2.Email = "jesusmrin29@gmail.com";
        //        model2.Password = "123456";
        //        model2.Rol = "admin";
        //        //model2.LastCreated = DateTime.Now;
        //        model2.LastUpdated = DateTime.Now;
        //        result = api.Update(model2);

        //        Assert.AreNotEqual(result, -1);
        //    }
    }
}

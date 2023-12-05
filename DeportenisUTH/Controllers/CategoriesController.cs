using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API.Models;
using DeportenisUTH.Models;
using Database;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Web.Services.Description;
using DeportenisUTH.Utils;

namespace DeportenisUTH.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController() 
        {
            //this._orderBy.Add("0", "Description");
            //this._orderBy.Add("1", "LastUpdate");
        }

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
            if(model.Id == 0)
            {
                result = api.Add(model);
            }
            else
            {
                result = api.UpdateCategory(model);
            }
            return View("Index");



        }
        public ActionResult Create()
        {
            //DeportenisUTH.Models.Category model = new DeportenisUTH.Models.Category();
            API.Models.Category model = new API.Models.Category();

            return View("_Edit",model);
        }
        public ActionResult getCategoriesList()
        {
            // Establecer los valores del grid, para la paginacion, ordenacion, filtrado, busqueda/
            DataTableNetManage objDTNetManage = new DataTableNetManage(Request);

            // Category departments = new Category(this.ambient);
            API.Catalogs.Category category = new API.Catalogs.Category();

            IQueryable<API.Models.Category> queryBrands = category.Query();
           // queryBrands = ExtensionMethods.OrderByField(queryBrands, this._orderBy[objDTNetManage.orderCol], objDTNetManage.bDescending);


            // Obtener el total de registros(recordsTotal) para indicarlos en el grid /
            objDTNetManage.recordsTotal = queryBrands.Count();

            // Filtro por si hay busqueda general /
            if (objDTNetManage.searchVal != "")
            {
                queryBrands = from res in queryBrands where res.Name.Contains(objDTNetManage.searchVal) select res;

            }
            // Obtener el total de registros filtrados(recordsFiltered) para indicarlos en el grid /
            objDTNetManage.recordsFiltered = queryBrands.Count();

            objDTNetManage.setPaginationRange();


            string ElementsSearched = JsonConvert.SerializeObject(queryBrands.ToList().GetRange(objDTNetManage.startFrom, objDTNetManage.lengthGrid));
            string sResult = "{ \"draw\":" + objDTNetManage.draw + ", \"recordsTotal\":" + objDTNetManage.recordsTotal + ",\"recordsFiltered\":" + objDTNetManage.recordsFiltered + ",\"data\":" + ElementsSearched + "}";


            return new ContentResult { Content = sResult, ContentType = "application/json" };
        }
        public ActionResult Delete(int id)
        {
            API.Catalogs.Category api = new API.Catalogs.Category();
            api.Delete(id);
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            API.Catalogs.Category api = new API.Catalogs.Category();
            API.Models.Category model = new API.Models.Category();
            Database.Category model2 = new Database.Category();
            
             model  = api.Find(id);
            return View("Index" , model);
        }
    }



}
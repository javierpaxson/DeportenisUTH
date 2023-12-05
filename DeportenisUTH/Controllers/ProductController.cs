using Database;
using DeportenisUTH.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeportenisUTH.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            API.Models.Products model = new API.Models.Products();

            return View("_Edit", model);
        }
        public ActionResult _Edit(API.Models.Products model)
        {
            API.Catalogs.Products api = new API.Catalogs.Products();
            int result = 0;

            model.LastUpdated = DateTime.Now;
            model.LastCreated = DateTime.Now;
            if (model.Id == 0)
            {
                result = api.Add(model);
            }
            else
            {
                result = api.Update(model);
            }
            return View("Index");
        }
        public ActionResult getProductList()
        {
            // Establecer los valores del grid, para la paginacion, ordenacion, filtrado, busqueda/
            DataTableNetManage objDTNetManage = new DataTableNetManage(Request);

            // Category departments = new Category(this.ambient);
            API.Catalogs.Products products = new API.Catalogs.Products();

            IQueryable<API.Models.Products> queryBrands = products.Query();
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
            API.Catalogs.Products api = new API.Catalogs.Products();
            api.Delete(id);
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            API.Catalogs.Products api = new API.Catalogs.Products();
            API.Models.Products model = new API.Models.Products();
            Database.Product model2 = new Database.Product();

            model = api.Find(id);
            return View("Index", model);
        }


    }
}
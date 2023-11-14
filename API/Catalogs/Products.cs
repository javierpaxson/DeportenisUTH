﻿using API.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalogs
{
    public class Products
    {
        DeportenisEntities entity = new DeportenisEntities();
        Database.Product dbProduct = new Database.Product();

        public int Add (Models.Products model)
        {
            int result = 0;
            //Database.User dbUser = new Database.User();
            try
            {
                dbProduct = this.entity.Products.Create();
                dbProduct.CategoryID = model.CategoryID;
                dbProduct.Name = model.Name;
                dbProduct.Description = model.Description;
                dbProduct.Price = model.Price;
                dbProduct.Stock = model.Stock;
                dbProduct.SaleOff = model.SaleOff;
                dbProduct.Date = model.Date;
                dbProduct.Image = model.Image;
                dbProduct.LastCreated = model.LastCreated;
                dbProduct.LastUpdated = model.LastUpdated;
                entity.Products.Add(dbProduct);
                entity.SaveChanges();
                result = dbProduct.Id;
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
        public int Delete(int id)
        {
            int result = 0;
            try
            {
                var resultProducts = entity.Products.Find(id);
                if (resultProducts != null)
                {
                    entity.Products.Remove(resultProducts);
                    entity.SaveChanges();
                    result = resultProducts.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
        public Database.Product Find(int id)
        {
            try
            {
                var resultProducts = entity.Products.Find(id);
                if (resultProducts != null)
                {
                    return resultProducts;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public int Update(Models.Products model)
        {
            int result = 0;
            try
            {
                var resultProduct = entity.Products.Find(model.Id);
                if (resultProduct != null)
                {
                    resultProduct.CategoryID = model.CategoryID;
                    resultProduct.Name = model.Name;
                    resultProduct.Description = model.Description;
                    resultProduct.Price = model.Price;
                    resultProduct.Stock = model.Stock;
                    resultProduct.SaleOff = model.SaleOff;
                    resultProduct.Date = model.Date;
                    resultProduct.Image = model.Image;
                    resultProduct.LastUpdated = model.LastUpdated;

                    this.entity.SaveChanges();
                    result = resultProduct.Id;
                }
            }
            catch (DbEntityValidationException ex) when ((ex.InnerException?.InnerException as SqlException)?.Number == 2601)
            {
                //2601 Violation in Unique index
                result = -1;
            }
            catch (Exception ex)
            {
                result = -1;

            }

            return result;
        }
    }
}
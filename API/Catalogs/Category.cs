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
    public class Category
    {
        DeportenisEntities entity = new DeportenisEntities();
        Database.Category dbCategory = new Database.Category();

        public int Add(Models.Category model)
        {
            int result = 0;
            //Database.User dbUser = new Database.User();
            try
            {
                dbCategory = this.entity.Categories.Create();
                dbCategory.Name = model.Name.ToUpper();
                dbCategory.LastCreated = model.LastCreated;
                dbCategory.LastUpdated = model.LastUpdated;
                entity.Categories.Add(dbCategory);
                entity.SaveChanges();
                result = dbCategory.Id;
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
                var resultCategories = entity.Categories.Find(id);
                if (resultCategories != null)
                {
                    entity.Categories.Remove(resultCategories);
                    entity.SaveChanges();
                    result = resultCategories.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
        public Models.Category Find(int id)
        {
            Models.Category model = null;
            try
            {
                //var resultCategories = entity.Categories.Find(id);
                this.dbCategory  = entity.Categories.Find(id);

                if (this.dbCategory != null)
                {
                    model = GetEntityModel();
                    return model;
                }
            }
            catch (Exception ex)
            {   
                return null;
            }
            return null;
        }
        public int UpdateCategory(Models.Category model)
        {
            int result = 0;
            try
            {
                var resultCategory = entity.Categories.Find(model.Id);
                if (resultCategory != null)
                {
                    resultCategory.Name = model.Name;
                    resultCategory.LastUpdated = model.LastUpdated;

                    this.entity.SaveChanges();
                    result = resultCategory.Id;
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
        public IQueryable<Models.Category> Query()
        {
            IQueryable<Models.Category> model = null;

            try
            {
                model = from r in entity.Categories
                        where r.Id >= 0
                        orderby r.Name ascending
                        select new Models.Category
                        {
                            Id = r.Id,
                            Name = r.Name,
                            LastCreated = r.LastCreated,
                            LastUpdated = r.LastUpdated
                        };
            }
            catch (Exception ex)
            {
                //this.Log(ex.ToString(), LogSeverity.Exception);
            }

            return model;
        }
        Models.Category GetEntityModel()
        {
            Models.Category model = new Models.Category()
            {
                Id = this.dbCategory.Id,
                Name = this.dbCategory.Name,
                LastCreated = this.dbCategory.LastCreated,
                LastUpdated = this.dbCategory.LastUpdated
            };
            return model;
        }
    }
}

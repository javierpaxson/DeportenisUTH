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
        public Database.Category Find(int id)
        {
            try
            {
                var resultCategories = entity.Categories.Find(id);
                if (resultCategories != null)
                {
                    return resultCategories;
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
    }
}

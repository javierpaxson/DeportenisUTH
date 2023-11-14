using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalogs
{
    public class LineOrders
    {
        DeportenisEntities entity = new DeportenisEntities();
        Database.LineOrder dbLineOrders = new Database.LineOrder();

        public int Add(Models.LineOrders model)
        {
            int result = 0;
            //Database.User dbUser = new Database.User();
            try
            {
                dbLineOrders = this.entity.LineOrders.Create();
                dbLineOrders.OrderID = model.OrderID;
                dbLineOrders.ProductID = model.ProductID;
                dbLineOrders.Units = model.Units;               
                dbLineOrders.LastCreated = model.LastCreated;
                dbLineOrders.LastUpdated = model.LastUpdated;
                entity.LineOrders.Add(dbLineOrders);
                entity.SaveChanges();
                result = dbLineOrders.Id;
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
                var resultLineOrders = entity.LineOrders.Find(id);
                if (resultLineOrders != null)
                {
                    entity.LineOrders.Remove(resultLineOrders);
                    entity.SaveChanges();
                    result = resultLineOrders.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
        public Database.LineOrder Find(int id)
        {
            try
            {
                var resultLineOrders = entity.LineOrders.Find(id);
                if (resultLineOrders != null)
                {
                    return resultLineOrders;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public int Update(Models.LineOrders model)
        {
            int result = 0;
            try
            {
                var resultLineOrders = entity.LineOrders.Find(model.Id);
                if (resultLineOrders != null)
                {
                    resultLineOrders.OrderID = model.OrderID;
                    resultLineOrders.ProductID = model.ProductID;
                    resultLineOrders.Units = model.Units;                   
                    resultLineOrders.LastUpdated = model.LastUpdated;

                    this.entity.SaveChanges();
                    result = resultLineOrders.Id;
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

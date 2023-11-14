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
    public class Orders
    {
        DeportenisEntities entity = new DeportenisEntities();
        Database.Order dbOrder = new Database.Order();

        public int Add(Models.Orders model)
        {
            int result = 0;
            //Database.User dbUser = new Database.User();
            try
            {
                dbOrder = this.entity.Orders.Create();
                dbOrder.UserID = model.UserID;
                dbOrder.City = model.City;
                dbOrder.Address = model.Address;
                dbOrder.Cost = model.Cost;
                dbOrder.Status = model.Status;
                dbOrder.Date = model.Date;
                dbOrder.Hour = model.Hour;
                dbOrder.LastCreated = model.LastCreated;
                dbOrder.LastUpdated = model.LastUpdated;
                entity.Orders.Add(dbOrder);
                entity.SaveChanges();
                result = dbOrder.Id;
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
                var resultOrders = entity.Orders.Find(id);
                if (resultOrders != null)
                {
                    entity.Orders.Remove(resultOrders);
                    entity.SaveChanges();
                    result = resultOrders.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
        public Database.Order Find(int id)
        {
            try
            {
                var resultOrders = entity.Orders.Find(id);
                if (resultOrders != null)
                {
                    return resultOrders;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public int Update(Models.Orders model)
        {
            int result = 0;
            try
            {
                var resultOrders = entity.Orders.Find(model.Id);
                if (resultOrders != null)
                {
                    resultOrders.UserID = model.UserID;
                    resultOrders.City = model.City;
                    resultOrders.Address = model.Address;
                    resultOrders.Cost = model.Cost;
                    resultOrders.Status = model.Status;
                    resultOrders.Date = model.Date;
                    resultOrders.Hour = model.Hour;
                    resultOrders.LastUpdated = model.LastUpdated;
                    this.entity.SaveChanges();
                    result = resultOrders.Id;
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

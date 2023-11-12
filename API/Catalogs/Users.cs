using System.Data.Entity.Validation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using API.Models;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity;

namespace API.Catalogs
{
    public class Users
    {

        DeportenisEntities entity = new DeportenisEntities();
        Database.User dbUser = new Database.User();

        public int Add(User model)
        {
            int result = 0;
            //Database.User dbUser = new Database.User();
            try
            {
                dbUser = this.entity.Users.Create();
                dbUser.Name = model.Name;
                dbUser.LastName = model.LastName;
                dbUser.Email = model.Email;
                dbUser.Password = model.Password;
                dbUser.Rol = model.Rol;
                dbUser.LastCreated = model.LastCreated;
                dbUser.LastUpdated = model.LastUpdated;
                entity.Users.Add(dbUser);
                entity.SaveChanges();
                result = dbUser.Id;
            }
            catch(Exception ex)
            {
                result = -1;
            }
            
            return result;
        }
        public User Find(int id)
        {
            try
            {
                var resultUsers = entity.Users.Find(id);
                if (resultUsers != null)
                {
                    return resultUsers;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }       
        
        public int Update(Models.Users model)
        {
            int result = 0;
            try
            {
                var resultUser = entity.Users.Find(model.Id);
                if (resultUser != null)
                {
                    resultUser.Name =  model.Name;
                    resultUser.LastName = model.LastName;
                    resultUser.Email = model.Email;
                    resultUser.Password = model.Password;
                    resultUser.Rol = model.Rol;                    
                    resultUser.LastUpdated = model.LastUpdated;

                    this.entity.SaveChanges();
                    result = resultUser.Id;
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
        public int Delete(int id)
        {
            int result = 0;
            try
            {
                var resultUsers = entity.Users.Find(id);
                if (resultUsers != null)
                {
                    entity.Users.Remove(resultUsers);
                    entity.SaveChanges();
                    result = resultUsers.Id;
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }
    }
}

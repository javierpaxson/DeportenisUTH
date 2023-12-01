using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DeportenisUTH.Utils
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> dataSource, string SortField, bool bDescending)
        {
            try
            {
                var parameter = Expression.Parameter(typeof(T), "p");
                var property = Expression.Property(parameter, SortField);
                var lambdaExpression = Expression.Lambda(property, parameter);

                string method = bDescending ? "OrderByDescending" : "OrderBy";
                Type[] types = new Type[] { dataSource.ElementType, lambdaExpression.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, dataSource.Expression, lambdaExpression);
                return dataSource.Provider.CreateQuery<T>(mce);
            }
            catch (Exception e)
            {
                string sLogError = e.ToString();
            }
            return dataSource;
        }
        public static void WriteLog(string sLine)
        {
            //string sFileName = Environment.CurrentDirectory + "\\" + "Elementos.log";
            string sFileName = "C:\\Inetpub\\wwwroot\\Checador\\Access.log";

            string sRes = "Si";
            StreamWriter log;
            if (sRes == "Si")
            {
                if (!File.Exists(sFileName))
                {
                    log = new StreamWriter(sFileName);
                }
                else
                {
                    log = File.AppendText(sFileName);
                }
                log.WriteLine("{0} {1}", DateTime.Now, sLine);
                log.Close();
            }
        }
    }
}
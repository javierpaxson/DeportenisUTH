using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services.Description;

namespace DeportenisUTH.Models
{
    public class DataTableNetManage
    {
        //Propiedades para los grids de los catálogos/
        public Int32 recordsTotal { get; set; }
        public Int32 recordsFiltered { get; set; }
        public int lengthGrid { get; set; }
        public int startFrom { get; set; }
        public int draw { get; set; }
        public string searchVal { get; set; }
        //Obtener el ordenamiento asc|desc/
        public string orderDir { get; set; }
        public bool bDescending { get; set; }

        //Obtener la columna por la que se quiero ordenar/
        public string orderCol { get; set; }
        public string columnOrdering { get; set; }


        public DataTableNetManage(HttpRequestBase reqObject)
        {
            //*Parametros del DataTable.net:   https://www.datatables.net/manual/server-side */

            this.lengthGrid = int.Parse(reqObject.Form["length"]);
            this.startFrom = int.Parse(reqObject.Form["start"]);


            this.draw = int.Parse(reqObject.Form["draw"]);
            this.searchVal = reqObject.Form["search[value]"].Trim().ToString();

            // Obtener el ordenamiento asc | desc /
            this.orderDir = reqObject.Form["order[0][dir]"];
            this.bDescending = false;

            // Obtener la columna por la que se quiero ordenar/
            this.orderCol = reqObject.Form["order[0][column]"];
            if (orderDir == "asc")
            {
                bDescending = false;
            }
            else
            {
                bDescending = true;
            }




        }
        public void setPaginationRange()
        {
            // Determinar el rango a seleccionar(Paginacion)/
            if (this.recordsFiltered - this.startFrom < this.lengthGrid)
            {
                this.lengthGrid = this.recordsFiltered - this.startFrom;
            }
            else
            {
                // El caso de vizualizar todos los elementos/
                if (this.lengthGrid == -1)
                {
                    this.lengthGrid = this.recordsFiltered;
                }

            }
        }
    }
}
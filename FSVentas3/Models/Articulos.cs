using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        public string Nombre { get; set; }

   
        public string Descripcion { get; set; }
        
        public string Marca { get; set; }

       
        public string NombreProveedor { get; set; }

     
        public string Categoria { get; set; }
       
        public int CantidadDispodible { get; set; }

        public int Cantidad { get; set; }

      
        public double Descuento { get; set; }

        public double PrecioCompra { get; set; }

        public double Precio { get; set; }

        public double Importe { get; set; }



      
        public DateTime Fecha { get; set; }

    }
}
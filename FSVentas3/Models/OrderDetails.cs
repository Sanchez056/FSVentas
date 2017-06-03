using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class OrderDetails
    {
        [Key]
       public int  OrderItemsId { get; set; }
       public int  OrderId { get; set; }
       public string  ItemName { get; set; }
       public int  Quantity { get; set; }
       public double Rate { get; set; }
       public double TotalAmount { get; set; }
    }
}
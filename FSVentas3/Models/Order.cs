using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSVentas3.Models
{
    public class Order
    {
        [Key]
       public  int OrderId { get; set; }
       public  string OrderNo { get; set; }
       public  DateTime OrderDate { get; set; }
       public  string Description { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }

}
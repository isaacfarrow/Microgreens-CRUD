using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microgreens.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ShippingPrice { get; set; }
        //      public DateTime DateIn { get; set; }
        //  public DateTime DateOut { get; set; }
        public SowRatesL SowRates { get; set; }
        public Yields Yield { get; set; }
    }
}

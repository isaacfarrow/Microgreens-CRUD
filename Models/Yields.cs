using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microgreens.Models
{
    public class Yields
    {
        [Key]
        public int YieldId { get; set; }
        public decimal Yield { get; set; }
        //  public decimal CostPerTray { get; set; }
        public int ProductsId { get; set; }
        //    public DateTime DateIn { get; set; }
        //  public DateTime DateOut { get; set; }
        public Products Product { get; set; }

    }
}

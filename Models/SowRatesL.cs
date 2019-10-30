using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microgreens.Models
{
    public class SowRatesL
    {
        [Key]
        public int SowRatesId { get; set; }
        public decimal SowWeight { get; set; }
        public int TraysPerPack { get; set; }
        public decimal CostPerTray { get; set; }
        public int ProductsId { get; set; }
        //    public DateTime DateIn { get; set; }
        //    public DateTime DateOut { get; set; }
        public Products Product { get; set; }
        public Yields Yield { get; set; }

    }
}

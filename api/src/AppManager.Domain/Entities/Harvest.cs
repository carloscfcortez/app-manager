using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager.Domain.Entities
{
    public class Harvest
    {
        public string Information { get; set; }
        public DateTime HarvestDate { get; set; }
        public decimal GrossWeight { get; set; }
        
    }
}

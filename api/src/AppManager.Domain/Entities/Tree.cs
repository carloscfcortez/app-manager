using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager.Domain.Entities
{
    public class Tree : EntityBase
    {
        public int SpecieId { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
    }
}

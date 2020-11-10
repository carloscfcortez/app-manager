using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager.Domain.Entities
{
    public class Specie : EntityBase
    {
        public string PopularName { get; set; }
        public string ScientificName { get; set; }

    }
}

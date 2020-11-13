using System;
using System.Collections.Generic;
using System.Text;
using AppManager.Domain.Entities;

namespace AppManager.Domain.Entities
{
  public class Harvest : EntityBase
  {
    public string Information { get; set; }
    public DateTime HarvestDate { get; set; }
    public decimal GrossWeight { get; set; }

    public int TreeId { get; set; }

    public virtual Tree Tree { get; set; }

  }
}

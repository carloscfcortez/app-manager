using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppManager.Domain.Entities
{
  public class Tree : EntityBase
  {
    public int SpecieId { get; set; }
    public int GroupId { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }

    public virtual Specie Specie { get; set; }

    public virtual Group Group { get; set; }
  }
}

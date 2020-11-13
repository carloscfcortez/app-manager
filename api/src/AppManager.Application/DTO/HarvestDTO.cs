using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Application.DTO
{
  public class HarvestDTO : BaseDTO
  {

    [Required]
    public int TreeId { get; set; }

    [StringLength(200)]
    public string Information { get; set; }


    [Required]
    public DateTime HarvestDate { get; set; }

    [Required]
    public decimal GrossWeight { get; set; }

    public TreeDTO Tree { get; set; }

  }
}

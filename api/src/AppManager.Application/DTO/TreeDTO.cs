using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Application.DTO
{
  public class TreeDTO : BaseDTO
  {

    [Required]
    public int SpecieId { get; set; }


    [Required]
    public int GroupId { get; set; }


    [Required]
    public int Age { get; set; }

    [StringLength(200)]
    public string Description { get; set; }

    public SpecieDTO Specie { get; set; }

    public GroupDTO Group { get; set; }


  }
}

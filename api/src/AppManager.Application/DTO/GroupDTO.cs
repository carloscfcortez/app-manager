using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Application.DTO
{
  public class GroupDTO : BaseDTO
  {
    [StringLength(150)]
    [Required]
    public string Name { get; set; }
  }
}

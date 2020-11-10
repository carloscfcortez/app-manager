using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Application.DTO
{
    public class SpecieDTO : BaseDTO
    {
        [StringLength(150)]
        [Required]
        public string PopularName { get; set; }


        [StringLength(150)]
        [Required]
        public string ScientificName { get; set; }

    }
}

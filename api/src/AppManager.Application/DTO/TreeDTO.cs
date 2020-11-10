using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppManager.Application.DTO
{
    public class TreeDTO : BaseDTO
    {

        [Required]
        public int SpecieId { get; set; }


        [Required]
        public int Age{ get; set; }

        [StringLength(200)]
        public string Description { get; set; }


        [StringLength(150)]
        [Required]
        public string ScientificName { get; set; }

    }
}

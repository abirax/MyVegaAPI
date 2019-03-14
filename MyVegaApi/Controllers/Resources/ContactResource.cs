using System.ComponentModel.DataAnnotations;

namespace MyVegaApi.Controllers.Resources
{
  public class ContactResource 
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

    }
}
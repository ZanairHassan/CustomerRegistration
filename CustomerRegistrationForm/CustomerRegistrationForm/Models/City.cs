using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationForm.Models
{
    [Table("tblCity")]
    public class City
    {
        [Key]
        public int City_id { get; set; }

        [Required(ErrorMessage = "City Name is required")]
        public string CityName { get; set; }
    }
}
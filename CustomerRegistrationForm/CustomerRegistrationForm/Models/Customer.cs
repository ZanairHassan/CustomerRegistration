using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerRegistrationForm.Models
{
    [Table("tblCustomers")]
    public class Customer
    {
        [Key]
        public int customer_id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int city_id { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        public string Details { get; set; }

        public DateTime Dated { get; set; } = DateTime.Now;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Entity
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[8,9]+\\d{7}$", ErrorMessage = "Not valid Singapore phone number")]
        public decimal PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$", ErrorMessage = "password does not satisfy criteria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

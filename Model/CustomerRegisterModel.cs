using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Model
{
    public class CustomerRegisterModel
    {
        public String FirstName { get; set; }

      
        public String LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password must be equal")]
        public String ConfirmPassword { get; set; }

    }
}

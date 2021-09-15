using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Model
{
    public class Customer:IdentityUser
    {

        

        public string FirstName { get; set; }

        public string LastName { get; set; }



    }
}

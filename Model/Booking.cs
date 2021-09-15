using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Model
{
    public class Booking
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Provience { get; set; }

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Key]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        
        public string SmookingRoom { get; set; }

        [DataType(DataType.Upload)]
        public string PhotoFileName { get; set; }

        public string SpecialNotes { get; set; }

    }
}

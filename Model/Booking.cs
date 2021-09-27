using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Model
{
    public class Booking
    {
        
        public int BookingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string Provience { get; set; }

        
        public string ZipCode { get; set; }

        [Required]
        public string Phone_Number { get; set; }

        
        public string PhotoFileName { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public string SmokingRoom { get; set; }


        public string LeasePocketWIFI { get; set; }

        

    }
}

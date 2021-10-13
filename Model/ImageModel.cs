using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Model
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

    }
}

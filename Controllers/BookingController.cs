using AutoMapper;
using Hotel_Management.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{


    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        

        [HttpGet("test")]
        public string test()
        {
            return "Hellow ";
        }

       

    }
}

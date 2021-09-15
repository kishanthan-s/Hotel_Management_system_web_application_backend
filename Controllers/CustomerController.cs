using AutoMapper;
using Hotel_Management.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMapper mapper;
        private UserManager<Customer> userManager;

        public CustomerController(IMapper mapper, UserManager<Customer>userManager)
        {

            this.mapper = mapper;
            this.userManager = userManager;
        }
      
        [Authorize]
        [HttpGet("test")]
        public string test()
        {
            return "Hellow ";
        }

        [HttpPost("register")]

        public async Task<ActionResult> Register(CustomerRegisterModel customerRegiserModel)
        {
           var user= mapper.Map<Customer>(customerRegiserModel);
           var result=  await  userManager.CreateAsync(user,customerRegiserModel.Password);
            
            if(result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]

        public async Task<ActionResult> Login(CustomerLoginModel customerLoginModel)
        {
            var user = await userManager.FindByEmailAsync(customerLoginModel.Email);

            if (user != null && await userManager.CheckPasswordAsync(user, customerLoginModel.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString }); 
            }

            return Unauthorized("Invalid username or password");
        }
    }
}

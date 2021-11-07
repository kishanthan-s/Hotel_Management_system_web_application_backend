using Hotel_Management.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly Databasecontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;



        

        public ImageController(Databasecontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }



    
        [HttpPost("{cus_ID}")]
        public IActionResult UploadImage(string cus_ID)
        {
            foreach (var file in Request.Form.Files)
            {
                ImageModel img = new ImageModel();
                img.ImageTitle = file.FileName;
                img.Customer_ID = cus_ID;

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.ImageData = ms.ToArray();

                ms.Close();
                ms.Dispose();

                _context.Images.Add(img);
                _context.SaveChanges();
            }
            ViewBag.Message = "Image(s) stored in database!";
            return StatusCode(200);
        }


       

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageModel>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }
            else
            {

                // Get image path  
                // string imgPath = System.IO.Path.Combine();
                // Convert image to byte array  
                //  byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                //Convert byte arry to base64string   
                // string imreBase64Data = Convert.ToBase64String(byteData);
                // string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                //Passing image data in viewbag to view  
                //  ViewBag.ImageData = imgDataURL;
                // return ViewBag.ImageData;

                Byte[] profilePicture = await _context.Images
                                 .Where(p => p.Id == id)
                                 .Select(p => p.ImageData)
                                 .FirstOrDefaultAsync();
                return File(profilePicture, "image/png");

            }




           
        }

        [HttpGet("test/{cus_ID}")]
        public  ActionResult Images_cus(string cus_ID)
        {
            var dataa = _context.Images.Where(m => m.Customer_ID == cus_ID).FirstOrDefault();

            if (dataa == null)
            {
                return Unauthorized("no image");
            }
            else
            {
                Byte[] profilePicture = _context.Images
                                 .Where(p => p.Customer_ID == cus_ID)
                                 .Select(p => p.ImageData)
                                 .FirstOrDefault();
                return File(profilePicture, "image/png");

              // var img = _context.Images.OrderByDescending
             //   (i => i.Customer_ID).FirstOrDefault();
             //   string imageBase64Data =
              //  Convert.ToBase64String(img.ImageData);
              ///  string imageDataURL =
             //    string.Format("data:image/jpg;base64,{0}",
              //   imageBase64Data);
             //  ViewBag.ImageTitle = img.ImageTitle;
             //   ViewBag.ImageDataUrl = imageDataURL;
              //  return imageDataURL;

            }

            

        }







    }

}


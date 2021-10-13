using AutoMapper;
using Hotel_Management.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{
    //you changed the entity frame work


    [Route("api/[Controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
       
        private readonly Databasecontext _context;

        public BookingController(Databasecontext context)
        {
            _context = context;
        }

        //new controller for get
        [HttpGet]
        public async Task<List<Booking>> GetAllBooks()
        {
            var data = await _context.Booking.ToListAsync();

            if (data == null)
            {
                
            }

            return data;

        }
        


        //[HttpGet("test")]
        //  public string test()
        //  {
        //    return "Hellow ";
        // }

        // [HttpGet]
        //  public async Task<ActionResult<IEnumerable<Booking>>> GetBookings(int id)
        // {
        //      return await _context.Booking.Where(x => x.BookingId == id).ToListAsync();
        // }




        //    [HttpGet("test1")]
        //     public async Task<ActionResult<Booking>> GetBooking(string Phone_Number)
        //   {
        //       var Booking = await _context.Booking.FindAsync(Phone_Number);
        //
        //       if (Booking == null)
        //      {
        //           return NotFound();
        //        }

        //        return Booking;
        //     }


        // private bool BookingExists(string Phone_Number)
        // {
        //      return _context.Booking.Any(e => e.Phone_Number == Phone_Number);
        // }

        /*  [HttpPost("request")]
           public async Task <ActionResult>Create(Booking booking)
           {
               if(ModelState.IsValid)
               {
                   _context.Booking.Add(booking);
                   await _context.SaveChangesAsync();
                   return StatusCode(201);
               }
               return StatusCode(400);
           }



           //[HttpGet("edit")]
          // public async Task<IActionResult> Edit(int? BookingId)
          // {
          //     if (BookingId == null || BookingId<=0)
           //        return BadRequest();

          //     var employeeinDb = await _context.Booking.FirstOrDefaultAsync(e => e.BookingId == BookingId);

           //    if (employeeinDb ==null)
           //        return NotFound();

          //     return StatusCode(201);
         //  }

           //[HttpDelete("{BookingId}")]
           // public async Task<ActionResult<Booking>> DeleteBooking(int BookingId)
           // {
           //     var booking = await _context.Booking.FindAsync(BookingId);
           //    if (booking == null)
           //    {
           //        return NotFound();
           //  }

           //  _context.Booking.Remove(booking);
           //   await _context.SaveChangesAsync();

           //   return booking;
           // }


           [HttpDelete("{id}")]
           public async Task<IActionResult> DeleteTodoItem(int id)
           {
               var todoItem = await _context.Booking.FindAsync(id);

               if (todoItem == null)
               {
                   return NotFound();
               }

               _context.Booking.Remove(todoItem);
               await _context.SaveChangesAsync();

               return NoContent();
           }

           [HttpGet("{id}")]
           public async Task<IActionResult>Edit(int? id)
           {
               if(id==null || id <=0)
                   return BadRequest();


               var employeeDb = await _context.Booking.FirstOrDefaultAsync(e => e.BookingId == id);

               if (employeeDb == null)
                   return NotFound();

               return StatusCode(202);
           }

           [HttpPost]
           public async Task<IActionResult>Edit(Booking booking)
           {
               if(!ModelState.IsValid)
                   return StatusCode(201);

               _context.Booking.Update(booking);

               await _context.SaveChangesAsync();

               return RedirectToAction(nameof(Index));
           }*/

        // POST: api/booking

        // GET: api/TodoItems/5



        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
             return //StatusCode(201);
            CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
        }


        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }

    }
}

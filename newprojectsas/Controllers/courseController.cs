using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newprojectsas.Controllers.Models;
using newprojectsas.Data;
using Microsoft.EntityFrameworkCore;


namespace newprojectsas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : ControllerBase
    {
        private readonly newprojectsasContext newprojectsasContext;
        private readonly newprojectsasContext _context;

        public courseController(newprojectsasContext newprojectsasContext, newprojectsasContext context)
        {
            this.newprojectsasContext = newprojectsasContext;
            _context = context;
        }

        // [HttpGet]
        //// [Route("Getcourses")]

        // public List<course> Getcourses()
        // {

        //     return newprojectsasContext.course.ToList();
        // }
        /*
                [HttpGet]
                [Route("Getcourse")]

                public stdinfo Getcourse(int id)
                {
                    return newprojectsasContext.course.Where(x=>x.courseid ==id).FirstOrDefault();
                }
        */

        [HttpGet]
        public async Task<ActionResult<IEnumerable<course>>> Getcourse()
        {
            return await _context.course.ToListAsync();
        }

        //[HttpGet]
        //[Route("Getcourse")]
        //public course Getcourse(int id)
        //{
        //    return newprojectsasContext.course.FirstOrDefault(x => x.courseid == id);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<course>> Getcourse(int id)
        {
            var course = await _context.course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }


        //[HttpPost]
        //[Route("Addcourse")]

        //public string Addcourse(course course)
        //{
        //    string response = string.Empty;
        //    newprojectsasContext.course.Add(course);
        //    newprojectsasContext.SaveChanges();
        //    return "course added";
        //}

        [HttpPost]
        public async Task<ActionResult<course>> PostBusDetails(course course)
        {
            _context.course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcourse", new { id = course.courseid }, course);
        }

        //[HttpPut]
        //[Route("Updatecourse")]

        //public string Updatecourse(course course)
        //{
        //    newprojectsasContext.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    newprojectsasContext.SaveChanges();

        //    return "course Updated";
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Putcourse(int id, course course)
        {
            if (id != course.courseid)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!courseExists(id))
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

        //[HttpDelete]
        //[Route("Deletecourse")]

        //public string Deletecourse(int id)
        //{
        //    course course = newprojectsasContext.course.Where(x => x.courseid == id).FirstOrDefault();

        //    if (course != null)
        //    {
        //        newprojectsasContext.course.Remove(course);
        //        newprojectsasContext.SaveChanges();

        //        return "course deleted";
        //    }
        //    else
        //    {
        //        return "No course found";
        //    }
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult<course>> Deletecourse(int id)
        {
            var course = await _context.course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.course.Remove(course);
            await _context.SaveChangesAsync();

            return course;
        }

        private bool courseExists(int id)
        {
            return _context.course.Any(e => e.courseid == id);
        }

    }
}

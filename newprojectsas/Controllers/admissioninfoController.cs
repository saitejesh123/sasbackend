using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newprojectsas.Controllers.Models;
using newprojectsas.Data;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;

namespace newprojectsas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class admissioninfoController : ControllerBase
    {
        private readonly newprojectsasContext _context;



        public admissioninfoController(newprojectsasContext newprojectsasContext, newprojectsasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<admissioninfo>>> Getadmissioninfo()
        {
            return await _context.admissioninfo.ToListAsync();
        }

        //[HttpGet]
        //[Route("Getadmissioninfos")]

        ////private readonly newprojectsasContext _context;
        //public List<admissioninfo> Getadmissioninfos()
        //{

        //    return newprojectsasContext.admissioninfo.ToList();
        //}

        //[HttpGet("{id}")]
        //[Route("Getadmissioninfo")]

        //public stdinfo Getadmissioninfo(int id)
        //{
        //    var admissioninfo = await _context.admissioninfo.FindAsync(id);
        //    if (admissioninfo == null)
        //            {
        //                return NotFound();
        //            }
        //        //try
        //        //{
        //        //    return await _admissioninfoRepository.Getadmissioninfo(id);
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        // _logger.LogError(ex.Message);
        //        return NotFound();
        //        //return newprojectsasContext.admissioninfo.Where(x => x.addid == id).FirstOrDefault();

        //        //return newprojectsasContext.admissioninfo.FirstOrDefault(x => x.addid == id);
        //    }

        [HttpGet("{id}")]
        public async Task<ActionResult<admissioninfo>> Getadmissioninfo(int id)
        {
            var admissioninfo = await _context.admissioninfo.FindAsync(id);

            if (admissioninfo == null)
            {
                return NotFound();
            }

            return admissioninfo;
        }

        [HttpPost]
        public async Task<ActionResult<admissioninfo>> PostBooking(admissioninfo admissioninfo)
        {
            _context.admissioninfo.Add(admissioninfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getadmissioninfo", new { id = admissioninfo.addid }, admissioninfo);
        }


        //[HttpPost]
        //[Route("Addadmissioninfo")]

        //public string Addadmissioninfo(admissioninfo admissioninfo)
        //{
        //    string response = string.Empty;
        //    newprojectsasContext.admissioninfo.Add(admissioninfo);
        //    newprojectsasContext.SaveChanges();
        //    return "admissioninfo added";
        //}

        //[HttpPost]
        //public async Task<ActionResult<admissioninfo>> Postadmissioninfo(admissioninfo admissioninfo)
        //{
        //    _context.admissioninfo(admissioninfo);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBooking", new { id = admissioninfo.addid }, admissioninfo);
        //}

        //[HttpPut]
        //[Route("Updateadmissioninfo")]

        //public string Updateadmissioninfo(admissioninfo admissioninfo)
        //{
        //    newprojectsasContext.Entry(admissioninfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    newprojectsasContext.SaveChanges();

        //    return "admissioninfo Updated";
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Putadmissioninfo(int id, admissioninfo admissioninfo)
        {
            if (id != admissioninfo.addid)
            {
                return BadRequest();
            }

            _context.Entry(admissioninfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!admissioninfoExists(id))
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
        //[Route("Deleteadmissioninfo")]

        //public string Deleteadmissioninfo(int id)
        //{
        //    admissioninfo admissioninfo = newprojectsasContext.admissioninfo.Where(x => x.addid == id).FirstOrDefault();

        //    if (admissioninfo != null)
        //    {
        //        newprojectsasContext.admissioninfo.Remove(admissioninfo);
        //        newprojectsasContext.SaveChanges();

        //        return "admissioninfo deleted";
        //    }
        //    else
        //    {
        //        return "No admission found";
        //    }
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<admissioninfo>> Deleteadmissioninfo(int id)
        {
            var admissioninfo = await _context.admissioninfo.FindAsync(id);
            if (admissioninfo == null)
            {
                return NotFound();
            }

            _context.admissioninfo.Remove(admissioninfo);
            await _context.SaveChangesAsync();

            return admissioninfo;
        }

        private bool admissioninfoExists(int id)
        {
            return _context.admissioninfo.Any(e => e.addid == id);
        }

    }
}

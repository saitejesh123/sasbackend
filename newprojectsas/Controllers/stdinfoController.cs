using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;

using newprojectsas.Repository.stdinfoRepository;
using Serilog;
using newprojectsas.Data;
using newprojectsas.Repository;
using newprojectsas.Controllers.Models;

namespace newprojectsas.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    // [ApiVersion("1")]
    public class stdinfoController : ControllerBase
    {
        //private readonly newprojectsasContext newprojectsasContext;

        private readonly newprojectsasContext _context;
        private readonly ILogger<stdinfoController> _logger;
       // private readonly IstdinfoRepository _stdinfoRepository;
       private readonly IstdinfoRepository _stdinfoRepository;

        public stdinfoController(newprojectsasContext context, ILogger<stdinfoController> logger,
            IstdinfoRepository stdinfoRepository)
        {
            _context = context;
            _logger = logger;
            _stdinfoRepository = stdinfoRepository;
        }



        // GET: api/RegisterUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo()
        {
            Log.Information("Getting all the users successfully.");
            //return Ok("u are using version 1");
            //return await _context.users.ToListAsync();
            return await _stdinfoRepository.Getstdinfo();
        }

        // GET: api/RegisterUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<stdinfo>> Getstdinfo(int id)
        {
            //var registerUser = await _context.users.FindAsync(id);

            //if (registerUser == null)
            //{
            _logger.LogWarning("Getting all the users successfully.");
            //    return NotFound();
            //}

            //return registerUser;
            try
            {
                return await _stdinfoRepository.Getstdinfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        // Authenticating user by their email and password
        // GET: api/RegisterUsers/sai123@gmail.com/sai123
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email, string password)
        {
            //try
            //{
            //    return await _registerUsersRepository.GetRegisterUserByPwd(email, password);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);

            //    return NotFound();
            //}

            Hashtable err = new Hashtable();
            try
            {
                var authUser = await _stdinfoRepository.GetstdinfoByPwd(email, password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("Login")]
        //public ActionResult Login(string email, string pwd)//([FromBody] User user)

        //{
        //    Hashtable err = new Hashtable();

        //    try
        //    {
        //        var result = _context.users.Where(x => x.Email.Equals(email) && x.Password.Equals(pwd)).FirstOrDefault();
        //        if (result != null) return Ok(result);
        //        else

        //        {

        //            err.Add("Status", "Error");

        //            err.Add("Message", "Invalid Credentials");

        //            return Ok(err);

        //        }
        //    }

        //    catch (Exception)

        //    {
        //        throw;

        //    }

        //    return null;
        //}

        // PUT: api/RegisterUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.






        [HttpPut("{id}")]
        public async Task<IActionResult> Putstdinfo(int id, stdinfo stdinfo)
        {
            //if (id != registerUser.UserId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(registerUser).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RegisterUserExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            _logger.LogInformation("User updated successfully.");
            //return NoContent();

            if (id != stdinfo.stdid)
            {
                return BadRequest();
            }

            _context.Entry(stdinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!stdinfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogWarning("Getting all the users successfully.");
            return NoContent();
        }

        // POST: api/RegisterUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo)
        {
            //_context.users.Add(registerUser);
            //await _context.SaveChangesAsync();
            _logger.LogWarning("Getting all the users successfully.");

            //return CreatedAtAction("GetRegisterUser", new { id = registerUser.UserId }, registerUser);
            await _stdinfoRepository.Poststdinfo(stdinfo);
            return CreatedAtAction("Getstdinfo", new { id = stdinfo.stdid }, stdinfo);
        }

        // DELETE: api/RegisterUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<stdinfo>> Deletestdinfo(int id)
        {
            try
            {
                return await _stdinfoRepository.Deletestdinfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        private bool stdinfoExists(int id)
        {
            return _stdinfoRepository.stdinfoExists(id);
        }
    }
}

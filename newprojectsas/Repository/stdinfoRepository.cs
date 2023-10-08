using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using newprojectsas.Repository.stdinfoRepository;
using newprojectsas.Data;
using newprojectsas.Controllers.Models;

namespace newprojectsas.Repository.stdinfoRepository
{
    public class stdinfoRepository : IstdinfoRepository
    {
        private readonly newprojectsasContext newprojectsasContext;
        private readonly newprojectsasContext _context;
        private readonly ILogger<stdinfoRepository> _logger;

        public stdinfoRepository(newprojectsasContext context, ILogger<stdinfoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo()
        {
            _logger.LogInformation("Getting all the users successfully.");
            return await _context.stdinfo.ToListAsync();
        }

        public async Task<ActionResult<stdinfo>> Getstdinfo(int id)
        {
            var registerUser = await _context.stdinfo.FindAsync(id);
            if (registerUser == null)
            {
                throw new NullReferenceException("Sorry, no user found with this id " + id);
            }
            else
            {
                return registerUser;
            }
        }

        public async Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email, string password)
        {
            var user = await _context.stdinfo.FirstOrDefaultAsync(x => x.email == email && x.password == password);
            if (user == null)
            {
                throw new NullReferenceException("Sorry, no user found with this credentials.");
            }
            else
            {
                return user;
            }
        }

        public async Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo)
        {
            _context.stdinfo.Add(stdinfo);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User created successfully.");

            return stdinfo;
        }

        public async Task<ActionResult<stdinfo>> Deletestdinfo(int id)
        {
            var registerUser = await _context.stdinfo.FindAsync(id);

            if (registerUser == null)
            {
                throw new NullReferenceException("Sorry, no user found with this id " + id);
            }
            else
            {
                _context.stdinfo.Remove(registerUser);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User deleted successfully.");

                return registerUser;
            }
        }

        public bool stdinfoExists(int id)
        {
            return _context.stdinfo.Any(e => e.stdid == id);
        }
    }
}


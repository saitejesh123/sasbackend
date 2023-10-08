using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace newprojectsas.Data
{
    public class newprojectsasContext : DbContext
    {
        public newprojectsasContext(DbContextOptions<newprojectsasContext> options)
            : base(options)
        {
        }

        public DbSet<newprojectsas.Controllers.Models.course> course { get; set; }

        public DbSet<newprojectsas.Controllers.Models.stdinfo> stdinfo { get; set; }

        public DbSet<newprojectsas.Controllers.Models.admissioninfo> admissioninfo { get; set; }

        public DbSet<newprojectsas.Controllers.Models.BankCred> BankCred { get; set; }


    }
}


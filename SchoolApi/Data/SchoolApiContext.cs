using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_API.Models;

namespace SchoolApi.Data
{
    public class SchoolApiContext : DbContext
    {
        public SchoolApiContext (DbContextOptions<SchoolApiContext> options)
            : base(options)
        {
        }

        public DbSet<School_API.Models.Student> Student { get; set; } = default!;
    }
}

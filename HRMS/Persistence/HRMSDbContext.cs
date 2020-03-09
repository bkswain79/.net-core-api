using HRMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Persistence
{
    public class HRMSDbContext: DbContext
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}

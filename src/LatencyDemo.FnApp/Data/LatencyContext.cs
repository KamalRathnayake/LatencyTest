using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatencyDemo.FnApp.Data
{
    internal class LatencyContext: DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("connection_string"));
        }
        public DbSet<LatencyTestRun> LatencyTestRun { get; set; }
    }
}

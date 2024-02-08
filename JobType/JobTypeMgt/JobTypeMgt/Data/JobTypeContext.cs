
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTypeMgt.models;

namespace JobTypeMgt.Data
{
    public class JobTypeContext : DbContext
    {
        public JobTypeContext(DbContextOptions<JobTypeContext> options)
            : base(options)
        {
        }

        public DbSet<JobTypeMgt.models.JobTypeDet> JobTypeDets { get; set; }

        public DbSet<JobTypeMgt.models.JobTypeHed> JobTypeHeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JobTypeDet>().ToTable("JobTypeDet");
            modelBuilder.Entity<JobTypeDet>().ToTable("JobTypeHed");
        }
    }
}




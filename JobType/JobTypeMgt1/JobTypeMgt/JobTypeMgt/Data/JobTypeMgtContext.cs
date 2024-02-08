using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobTypeMgt.models;

namespace JobTypeMgt.Data
{
    public class JobTypeMgtContext : DbContext
    {
        public JobTypeMgtContext (DbContextOptions<JobTypeMgtContext> options)
            : base(options)
        {
        }

        public DbSet<JobTypeMgt.models.JobTypeHed> JobTypeHeds { get; set; }
        public DbSet<JobTypeMgt.models.JobTypeDet> jobTypeDet { get; set; }

       // public int RecordId { get; set; }  
       //public DbSet<Student> Students { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTypeHed>().ToTable("JobTypeHed", "mst");
            modelBuilder.Entity<JobTypeDet>().ToTable("JobTypeDet", "mst");
           // base.OnModelCreating(modelBuilder);

            // Seeding data for JobTypeDets
            //modelBuilder.Entity<JobTypeMgt.models.JobTypeHed>().HasData(
            //    new JobTypeMgt.models.JobTypeDet { RecordId = 1, Name = "Value1", AnotherField = "AnotherValue" },
              
            //    // Add more hardcoded entries as needed
            //);

        }
    }
}

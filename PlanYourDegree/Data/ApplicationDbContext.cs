using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlanYourDegree.Models;

namespace PlanYourDegree.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DegreeReq> DegreeReqs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentTerm> StudentTerms { get; set; }
        public DbSet<DegreePlan> DegreePlans { get; set; }        
        public DbSet<DegreeTermReq> DegreeTermReqs { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<Degree>().ToTable("Degree");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<DegreeReq>().ToTable("DegreeReq");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<StudentTerm>().ToTable("StudentTerm");
            modelBuilder.Entity<DegreePlan>().ToTable("DegreePlan");            
            modelBuilder.Entity<DegreeTermReq>().ToTable("DegreeTermReq");           

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_Practice.Entities;

namespace EntityFramework_Practice.Context
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BusinessDb;User Id=rchn;Password=1234;Encrypt=False;TrustServerCertificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>()
                        .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });


            modelBuilder.Entity<ProjectEmployee>()
                        .HasOne(pe => pe.Project)
                        .WithMany(e => e.Employees)
                        .HasForeignKey(pe => pe.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                        .HasOne(pe => pe.Employee)
                        .WithMany(p => p.Projects)
                        .HasForeignKey(pe => pe.EmployeeId);

        }
    }
    public class Start
    {
        public static void Main(string[] args)
        {
        }
    }
}


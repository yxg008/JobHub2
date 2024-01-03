using ASPProject.EntityFramework;
using JobHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobHub.EntityFramework
{
    public class JobHubDbContext : IdentityDbContext<JobHubUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }

        public JobHubDbContext(DbContextOptions<JobHubDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Company entity
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name)
                .IsUnique();
       
            // Configure the JobSeeker entity
            modelBuilder.Entity<JobSeeker>()
                .HasIndex(js => js.EmailAddress)
                .IsUnique();
          

            // Seed data for Company
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    ID = 1,
                    Name = "Google",
                    OpenPosition = "SDE II",
                    Salary = 120000,
                    YearRequirement = 3,
                    Skill = Skills.Java,
                    Location = "Redmond, WA",
                    PostDate = DateTimeOffset.Now
                },
                new Company
                {
                    ID = 2,
                    Name = "Microsoft",
                    OpenPosition = "SDE I",
                    Salary = 110000,
                    YearRequirement = 2,
                    Skill = Skills.CSharp,
                    Location = "Redmond, WA",
                    PostDate = DateTimeOffset.Now
                },
                new Company
                {
                    ID = 3,
                    Name = "Amazon",
                    OpenPosition = "SDE III",
                    Salary = 130000,
                    YearRequirement = 4,
                    Skill = Skills.Python,
                    Location = "Seattle, WA",
                    PostDate = DateTimeOffset.Now
                },
                new Company
                {
                    ID = 4,
                    Name = "Facebook",
                    OpenPosition = "Front-end Developer",
                    Salary = 115000,
                    YearRequirement = 2,
                    Skill = Skills.Javascript,
                    Location = "Menlo Park, CA",
                    PostDate = DateTimeOffset.Now
                }
            );

            // Seed data for JobSeeker
            modelBuilder.Entity<JobSeeker>().HasData(
              new JobSeeker
              {
                  ID = 10,
                  firstName = "Alice",
                  lastName = "Smith",
                  EmailAddress = "alice.smith@gmail.com",
                  PhoneNumber = "123-456-7890",
                  Address = "Lacey, WA",
                  JobTitle = "Backend Developer"
              },
                new JobSeeker
                {
                    ID = 11,
                    firstName = "Bob",
                    lastName = "Jones",
                    EmailAddress = "bob.jones@gmail.com",
                    PhoneNumber = "234-567-8901",
                    Address = "Seattle ,WA",
                    JobTitle = "Java Developer"
                },
                new JobSeeker
                {
                    ID = 12,
                    firstName = "Carol",
                    lastName = "White",
                    EmailAddress = "carol.white@gmail.com",
                    PhoneNumber = "345-678-9012",
                    Address = "Dallas, TX",
                    JobTitle = "Software Development Engineer II (SDE II)"
                },
                new JobSeeker
                {
                    ID = 13,
                    firstName = "Dave",
                    lastName = "Brown",
                    EmailAddress = "dave.brown@gmail.com",
                    PhoneNumber = "456-789-0123",
                    Address = "Houston, TX",
                    JobTitle = "Software Engineer"
                }
            );
        }

    }
}

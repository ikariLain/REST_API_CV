using Microsoft.EntityFrameworkCore;
using REST_API_för_CV_hantering.Models;

namespace REST_API_för_CV_hantering.Data
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {
            
        }

        // This is the table that will be created in the database

        public DbSet<Person> Persons { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        //Test data for the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Person
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    PersonId = 1,
                    FirstName = "Matheus",
                    LastName = "Torrico",
                    Description = "A future fullstack developer within the .NET family of languages and practises. OOP, Agile, C#, EF Core, API, T-SQL, Database, Azure, React.",
                    Email = "Matheus.meme@hotmail.com",
                    MobileNumber = "+4206969144"
                },
                new Person
                {
                    PersonId = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Description = "Experienced software engineer with a passion for backend development.",
                    Email = "john.doe@example.com",
                    MobileNumber = "+4206969111"
                },
                new Person
                {
                    PersonId = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Description = "Frontend developer specializing in React and Angular.",
                    Email = "jane.smith@example.com",
                    MobileNumber = "+4206969222"
                }
            );

            // Seed data for Education
            modelBuilder.Entity<Education>().HasData(
                new Education
                {
                    EducationId = 1,
                    PersonId_FK = 1,
                    School = "Chas Academy",
                    Degree = "Full-stack web-dev, backend focus, APIs & services",
                    StartDate = new DateOnly(2024, 9, 2),
                    EndDate = null
                },
                new Education
                {
                    EducationId = 2,
                    PersonId_FK = 1,
                    School = "Huddinge",
                    Degree = "economics and law",
                    StartDate = new DateOnly(2022, 8, 22),
                    EndDate = new DateOnly(2023, 6, 9)
                },
                new Education
                {
                    EducationId = 3,
                    PersonId_FK = 2,
                    School = "Uppsala University",
                    Degree = "Computer Science",
                    StartDate = new DateOnly(2019, 9, 1),
                    EndDate = new DateOnly(2022, 6, 30)
                },
                new Education
                {
                    EducationId = 4,
                    PersonId_FK = 3,
                    School = "KTH Royal Institute of Technology",
                    Degree = "Software Engineering",
                    StartDate = new DateOnly(2017, 9, 1),
                    EndDate = new DateOnly(2020, 6, 30)
                }
            );

            // Seed data for Experience
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ExperienceId = 1,
                    PersonId_FK = 1,
                    JobTitle = ".NET Developer",
                    Company = "Consulting",
                    Description = "Worked on REST API",
                    StartDate = new DateOnly(2025, 1, 23),
                    EndDate = null
                },
                new Experience
                {
                    ExperienceId = 2,
                    PersonId_FK = 1,
                    JobTitle = "Self thougt programer",
                    Company = "Me",
                    Description = "Firebase, NoSQL TypScript",
                    StartDate = new DateOnly(2020, 3, 29),
                    EndDate = null
                },
                new Experience
                {
                    ExperienceId = 3,
                    PersonId_FK = 2,
                    JobTitle = "Backend Developer",
                    Company = "Chas Academy",
                    Description = ".NET framework",
                    StartDate = new DateOnly(2020, 7, 1),
                    EndDate = new DateOnly(2023, 6, 30)
                },
                new Experience
                {
                    ExperienceId = 4,
                    PersonId_FK = 3,
                    JobTitle = "Frontend Developer",
                    Company = "Chas Academy",
                    Description = "React + JS & TS, CSS, HTML and Vanila JS",
                    StartDate = new DateOnly(2019, 1, 1),
                    EndDate = new DateOnly(2021, 12, 31)
                }
            );
        }

    }
}

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

        DbSet<Person> Persons { get; set; }

        DbSet<Experience> Experience { get; set; }

        public DbSet<Education> Educations { get; set; }

    }
}

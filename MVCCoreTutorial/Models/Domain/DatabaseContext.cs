using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MVCCoreTutorial.Models.Domain
{
    public class DatabaseContext :DbContext
    {

      public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
    }
}

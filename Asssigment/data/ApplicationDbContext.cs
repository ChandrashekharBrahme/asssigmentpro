using Asssigment.Models;
using Microsoft.EntityFrameworkCore;

namespace Asssigment.data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) 
        {
            
        }
        public DbSet<Questions> Questions { get; set; }
    }
}

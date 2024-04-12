using Microsoft.EntityFrameworkCore;

using NewsAPP.Models.Excel;

namespace NewsAPP.Data
{
    public class ApplicationContext:DbContext
    {
        //for connecting database, we need to inherit Dbcontext properties.
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }


    }
}

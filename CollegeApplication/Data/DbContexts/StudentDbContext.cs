using CollegeApplication.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using CollegeApplication.Data.Configuration;

namespace CollegeApplication.Data.DbContexts
{
    public class StudentDbContext : DbContext
    {
       public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) 
       {
              
       }
        public DbSet<Student> StudentTable { get; set; }


        //Over-riding the On-ModalCreating method to seed some data to the entity in this case which is Student-Table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());           
        }        
    }
}

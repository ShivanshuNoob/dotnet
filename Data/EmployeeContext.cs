using Mvc.Models;
using Microsoft.EntityFrameworkCore;
namespace Mvc.Data{
    public class EmployeeContext:DbContext
    {
       public DbSet<Employee> employee {get;set;}

       protected override void OnConfiguring(DbContextOptionsBuilder builder){
             string conString="server=127.0.0.1;uid=root;pwd=root@123;database=transflower";
             builder.UseMySQL(conString);
       }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Employee>(entity => 
        {
          entity.HasKey(e => e.id);
          entity.Property(e => e.name).IsRequired();
          entity.Property(e => e.salary).IsRequired();
        });
        //modelBuilder.Entity<Employee>.toTable("employee");
    }
    
    }
}
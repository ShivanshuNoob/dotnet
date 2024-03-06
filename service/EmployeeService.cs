using System.Collections.Generic;
using Mvc.Models;
using Mvc.Data;

namespace Mvc.Services
{
    public class EmployeeService:IEmployeeService
    {
        public EmployeeService()
        {
        EmployeeContext db=new EmployeeContext();
        db.Database.EnsureCreated();
        }

        public List<Employee> GetProducts()
        {
            using (var context = new EmployeeContext())
            {
             var products = from prod in context.employee select prod;
             return products.ToList<Employee>();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var context = new EmployeeContext())
            {
             var product = context.employee.Find(id);
             return product;
            }
        }

        public bool Insert(Employee employee){
             using(var context = new EmployeeContext())
            {
                context.employee.Add(employee);
                context.SaveChanges(); 
            }
            return true;
        } 
       public bool Update(Employee employee){
            using(var context = new EmployeeContext())
            {
                var theProduct = context.employee.Find(employee.id);
                theProduct.name =employee.name;
                theProduct.salary=employee.salary;
                // theProduct.Description=product.Description;
                // theProduct.UnitPrice=product.UnitPrice;
                context.SaveChanges();
            }
            return true;
        }

        public bool Delete(int id){
            using (var context=new EmployeeContext())
            {
                var product=context.employee.Find(id);
                context.employee.Remove(product);
                context.SaveChanges();
                return true;
            }
        }
       
    }
}
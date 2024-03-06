using System;
using System.Collections.Generic;
using Mvc.Models;
using Mvc.Data;
namespace Mvc.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetProducts();
         Employee GetEmployeeById(int id);
         bool Insert(Employee employee);
         bool Update(Employee employee);
         bool Delete(int id);
    }
}
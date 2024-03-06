using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Mvc.Services;
using Mvc.Data;
namespace Mvc.Controllers;

public class EmployeeController: Controller
{
    
    private IEmployeeService _service; 
    public EmployeeController()
    {
       EmployeeService _svc=new EmployeeService();
       _service=_svc;
    }

    public IActionResult Index()
    {
        List<Employee>list=_service.GetProducts();
        return View(list);
    }

    public IActionResult Details(int id)
    {
        Employee emp=_service.GetEmployeeById(id);
        return View(emp);
    }

    public IActionResult Insert(){
         return View();
     }
     
    [HttpPost]
    public IActionResult Insert(Employee emp){   
        bool result=_service.Insert(emp);
        Console.WriteLine(result);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id){
        List<Employee> employees=_service.GetProducts();
        var e= employees.Find((emp)=>emp.id==id);    
        return View(e);
     }


    [HttpPost]
    public IActionResult Edit(Employee emp){   
      Console.WriteLine(emp.id+ " " + emp.name +"  "+ emp.salary);
            _service.Update(emp);
            return RedirectToAction("Index");
        }
     public IActionResult Delete(int id){   
             _service.Delete(id);
            return RedirectToAction("Index");
        }   
}

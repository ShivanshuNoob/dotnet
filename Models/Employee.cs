using System;
using System.ComponentModel.DataAnnotations;
namespace Mvc.Models{

public class Employee{

    public int id{get;set;}
    public string name{get; set;}
    
    [Required]
    public double salary{ get; set;}

}
}
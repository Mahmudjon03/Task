using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Domain.Enums;

namespace Domain.Entities;

public class Employee
{   [Key]
    public int Id { get; set; }

    [MaxLength(30)] 
    public string FirstName { get; set; } = null!;
    
    [MaxLength(30)]
    public string SurName { get; set; } = null!;
  
    [MaxLength(30)]
    public string FatherName{ get; set; } = null!;

    public string Jobtitle { get; set; } = null!;

    public List<Shift> Shift { get; set; } 


}
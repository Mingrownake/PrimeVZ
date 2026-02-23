using System;

namespace primeVZ.WebApi.Domain.Model;

public class Department
{
    public Guid Id {get; set;}
    public required string Name {get; set;}
    public ICollection<Employee> Employees {get; set;} = [];
}

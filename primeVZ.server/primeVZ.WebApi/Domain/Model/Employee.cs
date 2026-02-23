using System;

namespace primeVZ.WebApi.Domain.Model;

public class Employee
{
    public Guid Id {get; init;}
    public required string FirstName {get; set;}
    public required string LastName {get; set;}

    public Guid DepartmentId {get; set;}
    public Department Department {get; set;} = null!;
}

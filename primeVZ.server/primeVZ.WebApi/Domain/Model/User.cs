using System;

namespace primeVZ.WebApi.Domain.Model;

public class User
{
    public Guid Id {get; init;}
    public required string FirstName {get; set;}
    public required string SecondName {get; set;}
}

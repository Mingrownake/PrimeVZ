using System;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Application.Mappers;

public static class EmployeeMapperExtension
{
    public static EmployeeResponseDto MapToResponse(this Employee employee)
    {
        return new EmployeeResponseDto(
            Id: employee.Id,
            FirstName: employee.FirstName,
            LastName: employee.LastName
        );
    }

    public static IEnumerable<EmployeeResponseDto> MapToResponse(this IEnumerable<Employee> employees)
    {
        return employees.Select(x =>
        {
            return new EmployeeResponseDto(
                Id: x.Id,
                FirstName: x.FirstName,
                LastName: x.LastName
            );
        });
    }

    public static Employee MapToEntity(this EmployeeCreateDto employee)
    {
        return new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
    }
}

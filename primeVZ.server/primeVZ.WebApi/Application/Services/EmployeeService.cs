using System;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Application.Mappers;
using primeVZ.WebApi.Domain.Interfaces;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Application.Services;

public class EmployeeService(IEmployeeRepository employeeRepository)
{
    public async Task<EmployeeResponseDto?> GetEmployee(Guid id)
    {
        var employeeEntity = await employeeRepository.GetEmployee(id);
        return employeeEntity?.MapToResponse();
    }

    public async Task<IEnumerable<EmployeeResponseDto>> GetAllEmployee(string? term)
    {
        var employee = await employeeRepository.GetAllEmployee(term);
        return employee.MapToResponse();        
    }

    public async Task AddEmployee(EmployeeCreateDto employeeDto)
    {
        var employee = employeeDto.MapToEntity();
        await employeeRepository.AddEmployee(employee);
        await employeeRepository.SaveChanges();
    }

    public async Task DeleteEmployee(Guid employeeId)
    {
        employeeRepository.DeleteEmployee(employeeId);
        await employeeRepository.SaveChanges();
    }

    // public async Task UpdateUser(EmployeeResponseDto employeeDto)
    // {
    //     var employee = employeeDto.MapToEntity();
    //     employeeRepository.UpdateEmployee(employee);
    //     await employeeRepository.SaveChanges();
    // }
}

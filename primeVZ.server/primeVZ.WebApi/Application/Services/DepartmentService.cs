using System;
using primeVZ.WebApi.Application.DTO.Department;
using primeVZ.WebApi.Application.Mappers;
using primeVZ.WebApi.Domain.Interfaces;

namespace primeVZ.WebApi.Application.Services;

public class DepartmentService(IDepartmentRepository departmentRepository)
{
    public async Task<DepartmentResponseDto?> Get(Guid Id)
    {
        var department = await departmentRepository.Get(Id);
        return department?.MapToResponse();
    }

    public async Task<IEnumerable<DepartmentResponseDto>> GetAll()
    {
        var departments = await departmentRepository.GetAll();
        return departments.MapToResponse();
    }
}

using System;
using primeVZ.WebApi.Application.DTO.Department;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Application.Mappers;

public static class DepartmentMapperExtension
{
    public static DepartmentResponseDto MapToResponse(this Department department)
    {
        return new DepartmentResponseDto(
            Id: department.Id,
            Name: department.Name
        );
    }

    public static IEnumerable<DepartmentResponseDto> MapToResponse(this IEnumerable<Department> departments)
    {
        return departments.Select(x =>
        {
            return new DepartmentResponseDto(
                Id: x.Id,
                Name: x.Name
            );
        });
    }
}

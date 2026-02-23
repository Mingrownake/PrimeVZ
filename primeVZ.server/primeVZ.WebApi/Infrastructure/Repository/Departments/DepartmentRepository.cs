using System;
using primeVZ.WebApi.Domain.Interfaces;
using primeVZ.WebApi.Domain.Model;
using primeVZ.WebApi.Infrastructure.Db;

namespace primeVZ.WebApi.Infrastructure.Repository.Departments;

public class DepartmentRepository(ApplicationDataBase context) : IDepartmentRepository
{
    public async Task<Department?> Get(Guid Id)
    {
        return await context.Departments.FindAsync(Id);
    }

    public async Task<IEnumerable<Department>> GetAll()
    {
        return context.Departments;
    }
}

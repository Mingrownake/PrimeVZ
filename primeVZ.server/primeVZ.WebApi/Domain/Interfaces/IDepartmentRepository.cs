using System;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Domain.Interfaces;

public interface IDepartmentRepository
{
    public Task<IEnumerable<Department>> GetAll();
    public Task<Department?> Get(Guid Id);
}

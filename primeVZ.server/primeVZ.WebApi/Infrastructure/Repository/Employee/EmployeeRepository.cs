using Microsoft.EntityFrameworkCore;
using primeVZ.WebApi.Domain.Interfaces;
using primeVZ.WebApi.Domain.Model;
using primeVZ.WebApi.Infrastructure.Db;

namespace primeVZ.WebApi.Infrastructure.Repository.User;

public class EmployeeRepository(ApplicationDataBase context) : IEmployeeRepository
{
    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }

    public void DeleteEmployee(Guid id)
    {
        var employee = context.Employees.Find(id);
        if (employee is not null)
        {
            context.Employees.Remove(employee);
        }
    }

    public async Task<Employee?> GetEmployee(Guid id)
    {
        return await context.Employees.FindAsync(id);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployee(string? term)
    {
        var employeeQuery = context.Employees.AsQueryable();
        if (!string.IsNullOrEmpty(term) && !string.IsNullOrWhiteSpace(term))
        {
            employeeQuery = employeeQuery.Where(x => x.FirstName.Contains(term) || x.LastName.Contains(term));
        }
        return employeeQuery.AsEnumerable();
    }

    public async Task AddEmployee(Employee employee)
    {
        await context.Employees.AddAsync(employee);
    }

    public async void UpdateEmployee(Employee employee)
    {
        context.Employees.Update(employee);
    }
}

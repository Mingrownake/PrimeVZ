using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Domain.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee?> GetEmployee(Guid id);
    public Task<IEnumerable<Employee>> GetAllEmployee(string? term);
    public Task AddEmployee(Employee employee);
    public void DeleteEmployee(Guid employeeId);
    public void UpdateEmployee(Employee employee);
    public Task SaveChanges();
}

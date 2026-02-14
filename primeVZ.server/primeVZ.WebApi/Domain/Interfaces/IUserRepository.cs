using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Domain.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetUser(Guid id);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task AddUser(User user);
    public void DeleteUser(Guid userId);
    public void UpdateUser(User user);
    public Task SaveChanges();
}

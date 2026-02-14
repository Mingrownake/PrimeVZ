using System;
using Microsoft.EntityFrameworkCore;
using primeVZ.WebApi.Domain.Interfaces;
using primeVZ.WebApi.Infrastructure.Db;

namespace primeVZ.WebApi.Infrastructure.Repository.User;

public class UserRepository(ApplicationDataBase context) : IUserRepository
{
    public async Task AddUser(Domain.Model.User user)
    {
        await context.Users.AddAsync(user);
    }

    public async Task<IEnumerable<Domain.Model.User>> GetAllUsers()
    {
        return context.Users;
    }

    public async Task<Domain.Model.User?> GetUser(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }

    public void UpdateUser(Domain.Model.User user)
    {
        context.Users.Update(user);
    }

    public void DeleteUser(Guid id)
    {
        var user = context.Users.Find(id);
        if (user is not null)
        {
            context.Users.Remove(user);
        }
    }
}

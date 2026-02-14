using System;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Application.Mappers;
using primeVZ.WebApi.Domain.Interfaces;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Application.Services;

public class UserService(IUserRepository userRepository)
{
    public async Task<UserDto?> GetUser(Guid id)
    {
        var userEntity = await userRepository.GetUser(id);
        return userEntity?.MapToResponse();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        var users = await userRepository.GetAllUsers();
        return users.MapToResponse();        
    }

    public async Task AddUser(UserDto userDto)
    {
        var user = userDto.MapToEntity();
        await userRepository.AddUser(user);
        await userRepository.SaveChanges();
    }

    public async Task DeleteUser(Guid userId)
    {
        userRepository.DeleteUser(userId);
        await userRepository.SaveChanges();
    }

    public async Task UpdateUser(UserDto userDto)
    {
        var user = userDto.MapToEntity();
        userRepository.UpdateUser(user);
        await userRepository.SaveChanges();
    }
}

using System;
using primeVZ.WebApi.Application.DTO.User;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Application.Mappers;

public static class UserMapperExtension
{
    public static UserDto MapToResponse(this User user)
    {
        return new UserDto(
            id: user.Id,
            FirstName: user.FirstName,
            SecondName: user.SecondName
        );
    }

    public static IEnumerable<UserDto> MapToResponse(this IEnumerable<User> users)
    {
        return users.Select(x =>
        {
            return new UserDto(
                id: x.Id,
                FirstName: x.FirstName,
                SecondName: x.SecondName
            );
        });
    }

    public static User MapToEntity(this UserDto userDto)
    {
        return new User
        {
            Id = userDto.id ?? Guid.Empty,
            FirstName = userDto.FirstName,
            SecondName = userDto.SecondName
        };
    }
}

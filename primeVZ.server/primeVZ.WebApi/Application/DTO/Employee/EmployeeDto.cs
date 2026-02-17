namespace primeVZ.WebApi.Application.DTO.User;

public record EmployeeResponseDto(Guid Id, string FirstName, string LastName);

public record EmployeeCreateDto(string FirstName, string LastName);
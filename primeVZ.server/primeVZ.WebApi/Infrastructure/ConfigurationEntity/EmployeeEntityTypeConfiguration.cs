using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Infrastructure.ConfigurationEntity;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.FirstName)
            .IsRequired();
        builder
            .Property(x => x.LastName)
            .IsRequired();
    }
}

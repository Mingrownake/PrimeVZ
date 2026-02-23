using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeVZ.WebApi.Domain.Model;

namespace primeVZ.WebApi.Infrastructure.ConfigurationEntity;

public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasData(
            new Department
            {
                Id = Guid.Parse("9e161be8-ff83-4130-b37d-848ba94cf544"),
                Name = "Разработчики" 
            },
            new Department
            {
                Id = Guid.Parse("ab7a3b46-8d50-47fd-98f7-84be31f01394"),
                Name = "Тестировщики" 
            }
        );

        builder.HasMany<Employee>(x => x.Employees)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

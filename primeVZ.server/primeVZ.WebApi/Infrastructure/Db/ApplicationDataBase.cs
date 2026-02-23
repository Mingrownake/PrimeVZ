using System;
using Microsoft.EntityFrameworkCore;
using primeVZ.WebApi.Domain.Model;
using primeVZ.WebApi.Infrastructure.ConfigurationEntity;

namespace primeVZ.WebApi.Infrastructure.Db;

public class ApplicationDataBase(DbContextOptions<ApplicationDataBase> option) : DbContext(option)
{
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Department> Departments {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
        new DepartmentEntityTypeConfiguration().Configure(modelBuilder.Entity<Department>());
    }
}

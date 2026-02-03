using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.Persistence;

public partial class HumanResourceDbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

}
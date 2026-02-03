using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;

// MISMO namespace que el principal
namespace HumanResource.Infrastructure.Persistence;

public partial class HumanResourceDbContext
{
    public DbSet<Contract> Contracts => Set<Contract>();
}
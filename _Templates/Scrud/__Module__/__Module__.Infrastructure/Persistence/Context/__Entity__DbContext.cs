using Microsoft.EntityFrameworkCore;
using __Module__.Domain.Entities;

namespace __Module__.Infrastructure.Persistence.Context;
public partial class __Module__DbContext
{
    public DbSet<__Entity__> __Entity__s => Set<__Entity__>();
}
using Domain.Common;
using Domain.Groups;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface ISmartChargingDbContext : IUnitOfWork
    {
        DbSet<Group> Groups { get; set; }
    }
}

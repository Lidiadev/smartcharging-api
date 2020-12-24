using System;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Groups;

namespace Infrastructure.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ISmartChargingDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public GroupRepository(ISmartChargingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Group> AddAsync(Group group)
        {
            var entity = await _context.Groups.AddAsync(group);

            await _context.SaveChangesAsync();

            return entity.Entity;
        }
    }
}

using Domain.Common;
using System.Threading.Tasks;

namespace Domain.Groups
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> AddAsync(Group group);
    }
}

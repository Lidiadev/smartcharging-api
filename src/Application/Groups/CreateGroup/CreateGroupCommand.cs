using Domain.Groups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Groups.CreateGroup
{
    public class CreateGroupCommand : IRequest<long>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, long>
    {
        private readonly IGroupRepository _groupRepository;

        public CreateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public async Task<long> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var capacity = Ampere.Create(request.Capacity);

            var entity = new Group(request.Name, capacity);

            await _groupRepository.AddAsync(entity);

            return entity.Id;
        }
    }
}

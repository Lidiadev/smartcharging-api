using Domain.Groups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Groups.CreateGroupWithChargeStation
{
    public class CreateGroupWithChargeStationCommand : IRequest<long>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public IEnumerable<ChargeStationDTO> ChargeStations { get; set; }

        public CreateGroupWithChargeStationCommand()
        {
            ChargeStations = new List<ChargeStationDTO>();
        }
    }

    public class CreateGroupWithChargeStationHandler : IRequestHandler<CreateGroupWithChargeStationCommand, long>
    {
        private readonly IGroupRepository _groupRepository;

        public CreateGroupWithChargeStationHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public async Task<long> Handle(CreateGroupWithChargeStationCommand request, CancellationToken cancellationToken)
        {
            var capacity = Ampere.Create(request.Capacity);

            var entity = new Group(request.Name, capacity);

            foreach (var chargeStation in request.ChargeStations)
            {
                entity.TryAddChargeStation(chargeStation.Name, chargeStation.Connectors.Select(x => x.MaxCurrent));
            }

            await _groupRepository.AddAsync(entity);

            return entity.Id;
        }
    }
}

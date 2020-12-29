using System.Collections.Generic;

namespace Application.Groups.CreateGroupWithChargeStation
{
    public class ChargeStationDTO
    {
        public string Name { get; set; }

        public IEnumerable<ConnectorDTO> Connectors { get; set; }

        public ChargeStationDTO()
        {
            Connectors = new List<ConnectorDTO>();
        }
    }
}

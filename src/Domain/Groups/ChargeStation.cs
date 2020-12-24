using Domain.Common;
using System.Collections.Generic;

namespace Domain.Groups
{
    public class ChargeStation : Entity
    {
        public string Name { get; set; }
        public IList<Connector> Connectors { get; private set; }
        public Ampere SumMaxCurrent { get; private set; }

        public ChargeStation(string name, Connector connector)
        {
            Name = name;
            Connectors.Add(connector);
            SumMaxCurrent = connector.MaxCurrent;
        }

        public bool AddConnector(Connector connector)
        {
            if (Connectors.Count >= Constants.MaxConnectors)
                return false;

            Connectors.Add(connector);
            SumMaxCurrent += connector.MaxCurrent;

            return false;
        }
    }
}

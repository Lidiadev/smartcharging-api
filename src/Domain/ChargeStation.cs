using Domain.Common;
using System.Collections.Generic;

namespace Domain
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

        public void AddConnector(Connector connector)
        {
            Connectors.Add(connector);
            SumMaxCurrent += connector.MaxCurrent;
        }
    }
}

using Domain.Common;
using System.Collections.Generic;

namespace Domain
{
    public class ChargeStation : Entity
    {
        public string Name { get; set; }
        private IList<Connector> Connectors { get; set; }
    }
}

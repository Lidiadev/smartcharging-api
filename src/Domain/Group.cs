using Domain.Common;
using System.Collections.Generic;

namespace Domain
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public int CapacityInAmps { get; set; }
        private IList<ChargeStation> Connectors { get; set; }
    }
}

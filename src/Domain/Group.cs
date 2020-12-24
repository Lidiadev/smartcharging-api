using Domain.Common;
using System.Collections.Generic;

namespace Domain
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public Ampere Capacity { get; set; }
        private IList<ChargeStation> Connectors { get; set; }

        public Group(string name)
        {
            Name = name;
        }
    }
}

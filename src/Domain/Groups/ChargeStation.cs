using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Groups
{
    public class ChargeStation : Entity
    {
        public string Name { get; set; }
        public IList<Connector> Connectors { get; private set; }

        private readonly IList<Connector> _connectors;
        public virtual IReadOnlyCollection<Connector> Connector => _connectors.ToList();

        [NotMapped]
        public Ampere SumMaxCurrent { get; private set; }

        protected ChargeStation()
        {
            _connectors = new List<Connector>();
        }

        public ChargeStation(string name, Connector connector)
            : this()
        {
            if(connector == null)
                throw new ArgumentNullException(nameof(connector));

            Name = name;
            _connectors.Add(connector);
            SumMaxCurrent = connector.MaxCurrent;
        }

        public bool AddConnector(Connector connector)
        {
            if (_connectors.Count >= Constants.MaxConnectors)
                return false;

            _connectors.Add(connector);
            SumMaxCurrent += connector.MaxCurrent;

            return false;
        }
    }
}

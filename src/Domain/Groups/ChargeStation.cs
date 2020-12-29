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

        public ChargeStation(string name, List<int> maxCurrentList)
            : this()
        {
            if (maxCurrentList.Count < 1 || maxCurrentList.Count > Constants.MaxConnectors)
                throw new Exception("The number of connectors is not valid.");

            Name = name;
            SumMaxCurrent = Ampere.Default;

            foreach (var maxCurrent in maxCurrentList)
            {
                AddConnector(maxCurrent);
            }
        }

        public void AddConnector(int maxCurrent)
        {
            Connector connector = new Connector(Ampere.Create(maxCurrent));

            _connectors.Add(connector);
            SumMaxCurrent += connector.MaxCurrent;
        }

        public bool CanAddConnectors
            => _connectors.Count < Constants.MaxConnectors;
    }
}

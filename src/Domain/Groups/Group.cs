using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Groups
{
    public class Group : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public Ampere Capacity { get; set; }

        private readonly IList<ChargeStation> _chargeStations;
        public virtual IReadOnlyCollection<ChargeStation> ChargeStations => _chargeStations.ToList();

        private readonly Ampere _currentCapacity;

        protected Group()
        {
            _chargeStations = new List<ChargeStation>();
        }

        public Group(string name, Ampere capacity)
        {
            Name = name;
            Capacity = capacity ?? throw new ArgumentNullException(nameof(capacity));

            _currentCapacity = Ampere.Default;
        }

        public bool AddChargeStation(ChargeStation station)
        {
            if (_currentCapacity + station.SumMaxCurrent > Capacity)
                return false;

            _chargeStations.Add(station);

            return true;
        }
    }
}

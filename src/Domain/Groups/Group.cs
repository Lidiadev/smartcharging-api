using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Groups
{
    public class Group : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public Ampere Capacity { get; set; }
        public IList<ChargeStation> ChargeStations { get; private set; }

        private readonly Ampere _currentCapacity;

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

            ChargeStations.Add(station);

            return true;
        }
    }
}

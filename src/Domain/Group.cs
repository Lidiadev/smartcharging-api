using Domain.Common;
using System.Collections.Generic;

namespace Domain
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public Ampere Capacity { get; set; }
        public IList<ChargeStation> ChargeStations { get; private set; }

        private Ampere _currentCapacity;

        public Group(string name, Ampere capacity)
        {
            Name = name;
            Capacity = capacity;
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

using Domain.Common;
using System;

namespace Domain.Groups
{
    public class Connector : Entity
    {
        public Ampere MaxCurrent { get; set; }

        protected Connector()
        {
        }

        public Connector(Ampere maxCurrent)
        {
            MaxCurrent = maxCurrent ?? throw new ArgumentNullException(nameof(maxCurrent));
        }
    }
}
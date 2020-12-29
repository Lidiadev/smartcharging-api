using Domain.Common;
using System;

namespace Domain.Groups
{
    public class Ampere : ValueObject<Ampere>
    {
        public static readonly Ampere Default = new Ampere(0);
        public int Value { get; private set; }

        protected Ampere(int value)
        {
            Value = value;
        }

        public static Ampere Create(int value)
        {
            if (value <= 0)
                throw new Exception("The amps should not be less than 0.");

            return new Ampere(value);
        }

        protected override bool EqualsCore(Ampere other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static Ampere operator +(Ampere value1, Ampere value2)
        {
            return new Ampere(value1.Value + value2.Value);
        }

        public static bool operator >(Ampere value1, Ampere value2)
        {
            return value1.Value > value2.Value;
        }

        public static bool operator <(Ampere value1, Ampere value2)
        {
            return value1.Value < value2.Value;
        }
    }
}

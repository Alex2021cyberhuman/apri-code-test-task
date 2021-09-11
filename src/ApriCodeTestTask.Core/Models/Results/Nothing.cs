using System;

namespace ApriCodeTestTask.Core.Models.Results
{
    public class Nothing : IEquatable<Nothing>
    {
        private static Nothing? _value;

        public static Nothing Value => _value ??= new();

        public bool Equals(Nothing? other)
        {
            return true;
        }

        public override bool Equals(object? obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
using Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Core.ValueObjects.RequiredString;

namespace Domain.ResearchGroups.ValueObjects
{
    public class ResearchGroupName : ValueObject
    {
        public const int MaxLength = 100;

        public string Value { get; }

        private ResearchGroupName(string value)
        {
            Value = value;
        }

        // for EFCore
        private ResearchGroupName()
        {
            Value = null!;
        }
        public static Validation<ValidationError, ResearchGroupName> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();
            if (value.Length > MaxLength)
                return new TooLong(MaxLength);
            return new ResearchGroupName(value);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString()
        {
            return Value;
        }
        public abstract record ValidationError;
        public record IsNullOrWhitespace : ValidationError;
        public record TooLong(int MaxLength) : ValidationError;
    }
}

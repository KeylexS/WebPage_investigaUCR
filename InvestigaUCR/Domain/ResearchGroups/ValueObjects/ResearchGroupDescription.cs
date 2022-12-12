using Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResearchGroups.ValueObjects
{
    public class ResearchGroupDescription : ValueObject
    {
        public const int MaxLength = 1000000;

        public string Value { get; }

        private ResearchGroupDescription(string value)
        {
            Value = value;
        }

        // for EFCore
        private ResearchGroupDescription()
        {
            Value = null!;
        }
        public static Validation<ValidationError, ResearchGroupDescription> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();
            if (value.Length > MaxLength)
                return new TooLong(MaxLength);
            return new ResearchGroupDescription(value);
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


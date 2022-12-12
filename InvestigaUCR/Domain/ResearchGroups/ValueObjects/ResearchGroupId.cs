using Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ResearchGroups.ValueObjects
{
    public class ResearchGroupId : ValueObject
    {
        public const int MaxLength = 30;

        public string Value { get; }

        private ResearchGroupId(string value)
        {
            Value = value;
        }

        // for EFCore
        private ResearchGroupId()
        {
            Value = null!;
        }
        public static Validation<ValidationError, ResearchGroupId> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();
            if (value.Length > MaxLength)
                return new TooLong(MaxLength);
            //if (!Regex.IsMatch(value, @"/^[A-Z]+$/g", RegexOptions.IgnoreCase))
                //return new IsInvalidFormat();
            return new ResearchGroupId(value);
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
        //public record IsInvalidFormat : ValidationError;
    }
}

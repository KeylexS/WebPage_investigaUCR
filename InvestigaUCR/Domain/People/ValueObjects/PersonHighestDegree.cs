using Domain.Core.ValueObjects;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.People.ValueObjects
{
    public class PersonHighestDegree : ValueObject
    {
        public const int MaxLength = 5;
        public string Value { get; }

        /// <summary>
        /// Constructor for validation
        /// </summary>
        /// <param name="value"></param>
        public PersonHighestDegree(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructor for EF testing
        /// </summary>
        public PersonHighestDegree()
        {
            Value = null!;
        }

        /// <summary>
        /// Validates if string not null, length 5 and specific text
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Validation<ValidationError, PersonHighestDegree> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new IsNullOrWhitespace();
            }
            if (value.Length > MaxLength)
            {
                return new TooLong(MaxLength);
            }
            if (!(value.Equals("Dra.") || value.Equals("Dr.")
                || value.Equals("Bach.") || value.Equals("MSc.")
                || value.Equals("Lic.")))
            {
                return new InvalidHighestDegree();
            }
            return new PersonHighestDegree(value);
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
        public record InvalidHighestDegree : ValidationError;
    }
}

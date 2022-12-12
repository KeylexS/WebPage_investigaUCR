using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.ValueObjects;
using LanguageExt;

namespace Domain.People.ValueObjects
{
    public class PersonId : ValueObject
    {
        public const int MaxLength = 90;
        public string Value { get; }

        /// <summary>
        /// Constructor for Validation
        /// </summary>
        /// <param name="value"></param>
        public PersonId(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Constructor for EF test
        /// </summary>
        public PersonId()
        {
            Value = null!;
        }

        /// <summary>
        /// Validates if the person Id is 90 length, is not null and Contains @
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Validation<ValidationError, PersonId> TryCreate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new IsNullOrWhitespace();
            if (value.Length > MaxLength)
                return new TooLong(MaxLength);
            if (!value.Contains('@'))
                return new InvalidEmail();
            return new PersonId(value);
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
        public record InvalidEmail : ValidationError; 
    }
}

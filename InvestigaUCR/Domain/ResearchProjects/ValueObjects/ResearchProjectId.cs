using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Domain.Core.ValueObjects;

namespace Domain.ResearchProjects.ValueObjects
{
    public class ResearchProjectId : ValueObject
    {
        public string Id { get; }

        public ResearchProjectId()
        {
            Id = null!;
        }

        private ResearchProjectId(string id)
        {
            Id = id;
        }
 


        public static Validation<ValidationError, ResearchProjectId> TryCreate(string? id)
        {
            bool IsMatch = false;
            if (id == null)
            {
                return new IdIsNull();
            } else
            {
                string pattern = @"\d\d\d-\w\w-\w\w\w?";
                IsMatch = Regex.IsMatch(id, pattern, RegexOptions.IgnoreCase);
            }
            if (!IsMatch)
            {
                return new WrongFormatId();

            }
            return new ResearchProjectId(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public override string ToString()
        {
            return Id;
        }

        public abstract record ValidationError;
        public record IdIsNull : ValidationError;
        public record WrongFormatId : ValidationError;
    }
}

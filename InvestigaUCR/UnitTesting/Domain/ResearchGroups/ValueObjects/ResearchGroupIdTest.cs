using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.ValueObjects;
using FluentAssertions;

namespace UnitTesting.Domain.ResearchGroups.ValueObjects
{
    public class ResearchGroupIdTest
    {
        [Fact]
        public void TryCreateEmptyIdReturnValidationError()
        {
            var input = string.Empty;

            var result = ResearchGroupId.TryCreate(input);

            result.IsFail.Should().BeTrue();
            result.Fail().Should().Be(new ResearchGroupId.IsNullOrWhitespace());
        }

        [Fact]
        public void TryCreateNullIdReturnValidationError()
        {
            string? input = null;

            var result = ResearchGroupId.TryCreate(input);

            result.IsFail.Should().BeTrue();
            result.Fail().Should().Be(new ResearchGroupId.IsNullOrWhitespace());
        }

        [Fact]
        public void TryCreateShortIdShouldReturnResearchGroupId()
        {
            var input = "CRUCRCITIC";

            var result = ResearchGroupId.TryCreate(input);

            result.IsSuccess.Should().BeTrue();
            result.Success().Value.Should().Be(input);
        }

        [Fact]
        public void TryCreateMaxLengthIdShouldReturnResearchGroupId()
        {
            var input = new string('A', ResearchGroupId.MaxLength);

            var result = ResearchGroupId.TryCreate(input);

            result.IsSuccess.Should().BeTrue();
            result.Success().Value.Should().Be(input);
        }
        [Fact]
        public void TryCreateTooLongIdShouldReturnnValidationError()
        {
            var input = new string('A', ResearchGroupId.MaxLength + 1);

            var result = ResearchGroupId.TryCreate(input);

            result.IsSuccess.Should().BeFalse();
            result.Fail().Should().Be(new ResearchGroupId.TooLong(ResearchGroupId.MaxLength));
        }

        [Fact]
        public void ResearchIdSameValueAreEquals()
        {
            var input = "Prueba1";
            var id1 = ResearchGroupId.TryCreate(input);
            var id2 = ResearchGroupId.TryCreate(input);

            var researchGroupId1 = id1.Success();
            var researchGroupId2 = id2.Success();

            researchGroupId1.Should().Be(researchGroupId2);
        }
    }
}

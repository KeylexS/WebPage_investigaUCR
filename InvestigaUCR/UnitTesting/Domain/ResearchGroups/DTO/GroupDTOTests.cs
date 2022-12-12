using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.ValueObjects;
using FluentAssertions;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Core.ValueObjects.RequiredString;

namespace UnitTesting.Domain.ResearchGroups.DTO
{
    //US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-573 Update the Unit test

    public class GroupDTOTests
    {
        [Fact]
        public void GroupDTOTestInstance()
        {
            // arrange
            byte[] test = { 1, 1, 1 };
            var groupTest = new { Id = ResearchGroupId.TryCreate("HC").Success(), Name = ResearchGroupName.TryCreate("name").Success(), 
                Description = ResearchGroupDescription.TryCreate("Generic description to do testing").Success(), Image = test};
            // act 
            byte[] aux = { 1, 1, 1 };
            var group = new GroupDTO(ResearchGroupId.TryCreate("HC").Success(), ResearchGroupName.TryCreate("name").Success(), ResearchGroupDescription.TryCreate("Generic description to do testing").Success(), aux);

            // assert
            groupTest.Should().BeEquivalentTo(group);
        }
    }
}

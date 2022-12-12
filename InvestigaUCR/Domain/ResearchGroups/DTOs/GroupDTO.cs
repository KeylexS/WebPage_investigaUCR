using Domain.Core.ValueObjects;
using Domain.ResearchGroups.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User story; SD-RG-1.5 & TT: PIIB22II02-288 Create the group DTO
namespace Domain.ResearchGroups.DTOs
{
    /// <summary>
    /// Class <c>GroupDTO</c> Group Data Tranfer Objects
    /// </summary>
    public class GroupDTO
    {
        public ResearchGroupId Id { get; }

        public ResearchGroupName Name { get; set; }

        public ResearchGroupDescription Description { get; }

        //US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-571 Add image variable on Entity and DTO
        public byte[]? Image { get; }

        /// <summary>
        /// GroupDTO class parameterized constructor.
        /// </summary>
        /// <param name="id">The id of the group</param>
        /// <param name="name">The name of the group</param>
        /// <param name="description">The description of the group</param>
        /// <param name="img">The image of the group</param>
        public GroupDTO(ResearchGroupId id, ResearchGroupName name, ResearchGroupDescription description, byte[]? img)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = img;
        }
    }
}
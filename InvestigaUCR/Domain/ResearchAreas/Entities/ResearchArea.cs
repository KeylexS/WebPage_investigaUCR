using Domain.Core.Exceptions;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResearchAreas.Entities
{
    public class ResearchArea
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; }

        private readonly List<Group> _researchGroup;
        public IReadOnlyCollection<Group> ResearchGroup => _researchGroup.AsReadOnly();

        private readonly List<ResearchProject> _projects;
        public IReadOnlyCollection<ResearchProject> Projects => _projects.AsReadOnly();


        public ResearchArea()
        {
            Id = 0;
            Name = "";
            Description = "";
            _researchGroup = null!;
            _projects = null!;
        }

        public ResearchArea(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            _researchGroup = new List<Group>();
            _projects = new List<ResearchProject>();
        }

        public void addGroupToReseachArea(Group group)
        {
            if (ResearchGroup.Exists(a => a == group))
                throw new DomainException("El area ya esta agregada al grupo.");
            _researchGroup.Add(group);
        }

    }
}

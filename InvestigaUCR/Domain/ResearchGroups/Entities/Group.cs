using Domain.Core.Entities;
using Domain.ResearchProjects.Entities;
using LanguageExt;
using Domain.ResearchAreas.Entities;
using Domain.Publications.Entities;
using Domain.News.Entities;
using Domain.ResearchGroups.ValueObjects;
using Domain.Core.Exceptions;
using Domain.People.Entities;
using Domain.Theses.Entities;

// User story: SD-RG-1.5 TT:PIIB22II02-282 
namespace Domain.ResearchGroups.Entities
{
    /// <summary>
    /// Class <c>Group</c> Models a research group.
    /// </summary>
    public class Group : AggregateRoot
    {

        public ResearchGroupId Id { get; set; }        
        public int ResearchCenterId { get; set; }
        public ResearchGroupName Name { get; set; }
        public ResearchGroupDescription Description { get; set; }
        public DateTime? Start_Date { get; set; }

        //US: PIIB22II02-350 SD-RG-1.6 Show the custom image for each groups in research groups list && TT: PIIB22II02-571 Add image variable on Entity and DTO
        public byte[]? Image { get; set; }       

        private readonly List<GroupNews> _news; //*CQL        
        public IReadOnlyCollection<GroupNews> News => _news.AsReadOnly();//*CQL

        //US: PIIB22II02-496 SD-RG-1.10 Show group's research area && TT: PIIB22II02-496 SD-RG-1.10 Show group's research area
        private readonly List<ResearchArea> _researchArea;
        public IReadOnlyCollection<ResearchArea> ResearchArea => _researchArea.AsReadOnly();

        //US: PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page && TT:PIIB22II02-648 Add a list of ResearchProjects to the group entity in the domain
        public List<ResearchProject> _researchProjects;
        //US: PIIB22II02-500 SD-RG-3.5 Show a preview of the research project on the research group page && TT:PIIB22II02-648 Add a list of ResearchProjects to the group entity in the domain
        public IReadOnlyCollection<ResearchProject> ResearchProjects => _researchProjects.AsReadOnly();

        //US: PIIB22II02-504 SD-RG-3.6 Show a preview of the publications on the research group page TT:PIIB22II02-752 Add Reference of publications and groups in domain entities
        public List<Publication> _publications;
        public IReadOnlyCollection<Publication> Publications => _publications;

        public List<Thesis> _thesis;
        public IReadOnlyCollection<Thesis> Thesis => _thesis.AsReadOnly();

        public Person? Coordinator { get; set; }

        public List<Person> _person;
        public IReadOnlyCollection<Person> Person => _person.AsReadOnly();

        /// <summary>
        /// Group class parameterized constructor.
        /// </summary>
        /// <param name="id">The id of the group</param>
        /// <param name="centerId">The id of the research center associated to the group</param>
        /// <param name="name">The name of the group</param>
        /// <param name="description">The description of the group</param>
        /// <param name="img">The image of the group</param>
        public Group(ResearchGroupId id, int centerId, ResearchGroupName name, ResearchGroupDescription description, byte[]? img, DateTime? startdate)
        {
            Id = id;
            ResearchCenterId = centerId;
            Name = name;
            Description = description;
            Image = img;
            Start_Date = startdate;
            _researchProjects = new List<ResearchProject>();
            _researchArea = new List<ResearchArea>();
            _publications = new List<Publication>();
            _news = new List<GroupNews>();
            _person = new List<Person>();
            _thesis = new List<Thesis>();
        }

        /// <summary>
        /// Group class default constructor.
        /// </summary>
        public Group()
        {
            Id = null!;
            Name = null!;
            Description = null!;
            Image = null!;
            Start_Date = null!;
            _researchProjects = null!;
            _researchArea = null!;
            _publications = null!;
            _news = null!;
            _thesis = null!;
            Coordinator = null!;
            _person = null!;
        }

        public void addResearchProjectToGroup(ResearchProject researchProject)
        {
            if (_researchProjects.Exists(a => a.Id == researchProject.Id))
                throw new DomainException("El proyecto ya está agregado al grupo.");
            _researchProjects.Add(researchProject);
        }

        public void addResearchProjectsToGroup(List<ResearchProject> researchProjects)
        {
            if (researchProjects.Count() == 0)
                throw new DomainException("No se seleccionó ninguna persona.");
            foreach (var project in researchProjects)
            {
                this.addResearchProjectToGroup(project);
            }
        }

        public void addResearchAreatoGroup(ResearchArea area)
        {
            if (_researchArea.Exists(a => a.Id == area.Id))
                throw new DomainException("El area ya esta agregada al grupo.");
            _researchArea.Add(area);
        }
        public void addResearchAreatosGroup(Group group, List<ResearchArea> selectedAreas)
        {
            if(selectedAreas.Count() == 0)
                throw new DomainException("No se selecciono ningun Area");
            foreach (var area in selectedAreas)
            {
                group.addResearchAreatoGroup(area);
            }
        }
        public void RemoveResearchArea(ResearchArea area)
        {
            if (_researchArea.Exists(p => p == area))
            {
                _researchArea.Remove(area);
            }
        }

        public void RemoveResearchProject(ResearchProject project)
        {
            if (_researchProjects.Exists(p => p == project))
            {
                _researchProjects.Remove(project);
            }
        }

        public void RemoveResearchProjects(Group group, List<ResearchProject> selectedProjects)
        {
            if (selectedProjects.Count() == 0)
                throw new DomainException("No se seleccionó ningún proyecto.");
            foreach (var project in selectedProjects)
            {
                group.RemoveResearchProject(project);
            }
        }

        /// <summary>
        /// Method <c>addResearcherToGroup</c> Adds a new researcher to a research group.
        /// </summary>
        /// <param name="person">Instance of the researcher to add</param>
        /// <exception cref="DomainException"></exception>
        public void addResearcherToGroup(Person person)
        {
            if (_person.Exists(a => a.Id == person.Id))
                throw new DomainException("La persona ya está agregada al grupo.");
            _person.Add(person);
        }

        /// <summary>
        /// Method <c>addResearchersToGroup</c> Adds a list of researchers to a research group
        /// </summary>
        /// <param name="selectedPeople">List of researchers to add</param>
        /// <exception cref="DomainException"></exception>
        public void addResearchersToGroup(List<Person> selectedPeople)
        {
            if (selectedPeople.Count() == 0)
                throw new DomainException("No se seleccionó ninguna persona.");
            foreach (var person in selectedPeople)
            {
                this.addResearcherToGroup(person);
            }
        }

        /// <summary>
        /// Method <c>removeResearcher</c> Removes a researcher from a research group.
        /// </summary>
        /// <param name="person">Instance of the researcher to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removeResearcher(Person person)
        {
            if (!_person.Exists(a => a.Id == person.Id))
                throw new DomainException("La persona no está asociada al grupo");
            _person.Remove(person);
        }

        /// <summary>
        /// Method <c>removeResearchers</c> Removes a list of researchers from a research group
        /// </summary>
        /// <param name="selectedPeople">List of researchers to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removeResearchers(List<Person> selectedPeople)
        {
            if (selectedPeople.Count() == 0)
                throw new DomainException("No se seleccionó ninguna persona.");
            foreach (var person in selectedPeople)
            {
                this.removeResearcher(person);
            }
        }

        /// <summary>
        /// Method <c>addPublicationToGroup</c> Adds a new publication to a research group.
        /// </summary>
        /// <param name="publication">Instance of the publication to add</param>
        /// <exception cref="DomainException"></exception>
        public void addPublicationToGroup(Publication publication)
        {
            if (_publications.Exists(a => a.DOI == publication.DOI))
                throw new DomainException("La publicación ya está agregada al grupo.");
            _publications.Add(publication);
        }

        /// <summary>
        /// Method <c>addPublicationsToGroup</c> Adds a list of publications to a research group
        /// </summary>
        /// <param name="selectedPublications">List of publications to add</param>
        /// <exception cref="DomainException"></exception>
        public void addPublicationsToGroup(List<Publication> selectedPublication)
        {
            if (selectedPublication.Count() == 0)
                throw new DomainException("No se seleccionó ninguna publicación.");
            foreach (var publication in selectedPublication)
            {
                this.addPublicationToGroup(publication);
            }
        }

        /// <summary>
        /// Method <c>removePublication</c> Removes a publication from a research group.
        /// </summary>
        /// <param name="publication">Instance of the publication to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removePublication(Publication publication)
        {
            if (!_publications.Exists(a => a.DOI == publication.DOI))
                throw new DomainException("La publicación no está asociada al grupo.");
            _publications.Remove(publication);
        }

        /// <summary>
        /// Method <c>removePublications</c> Removes a list of publications from a research group.
        /// </summary>
        /// <param name="selectedPublications">List of publications to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removePublications(List<Publication> selectedPublications)
        {
            if (selectedPublications.Count() == 0)
                throw new DomainException("No se seleccionó ninguna publicación.");
            foreach (var publication in selectedPublications)
            {
                this.removePublication(publication);
            }
        }

        /// <summary>
        /// Method <c>addThesisToGroup</c> Adds a new thesis to a research group.
        /// </summary>
        /// <param name="thesis">Instance of the thesis to add</param>
        /// <exception cref="DomainException"></exception>
        public void addThesisToGroup(Thesis thesis)
        {
            if (_thesis.Exists(a => a.Id == thesis.Id))
                throw new DomainException("La tesis ya está agregada al grupo.");
            _thesis.Add(thesis);
        }

        /// <summary>
        /// Method <c>addThesesToGroup</c> Adds a list of theses to a research group
        /// </summary>
        /// <param name="selectedTheses">List of theses to add</param>
        /// <exception cref="DomainException"></exception>
        public void addThesesToGroup(List<Thesis> selectedTheses)
        {
            if (selectedTheses.Count() == 0)
                throw new DomainException("No se seleccionó ninguna tesis.");
            foreach (var thesis in selectedTheses)
            {
                this.addThesisToGroup(thesis);
            }
        }

        /// <summary>
        /// Method <c>removeThesis</c> Removes a thesis from a research group.
        /// </summary>
        /// <param name="thesis">Instance of the thesis to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removeThesis(Thesis thesis)
        {
            if (!_thesis.Exists(a => a.Id == thesis.Id))
                throw new DomainException("La tesis no está asociada al grupo.");
            _thesis.Remove(thesis);
        }

        /// <summary>
        /// Method <c>removeTheses</c> Removes a list of theses from a research group.
        /// </summary>
        /// <param name="selectedTheses">List of theses to remove</param>
        /// <exception cref="DomainException"></exception>
        public void removeTheses(List<Thesis> selectedTheses)
        {
            if (selectedTheses.Count() == 0)
                throw new DomainException("No se seleccionó ninguna tesis.");
            foreach (var thesis in selectedTheses)
            {
                this.removeThesis(thesis);
            }
        }
    }
}

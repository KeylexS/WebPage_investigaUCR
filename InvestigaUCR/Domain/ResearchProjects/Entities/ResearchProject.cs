using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchGroups.Entities;
using Domain.People.Entities;
using Domain.Publications.Entities;
using Domain.ResearchAreas.Entities;
using Domain.ResearchProjects.ValueObjects;
using Domain.Theses.Entities;
using Domain.Core.ValueObjects;
using System.Collections;
using Domain.Publications.DTOs;
using Domain.ResearchGroups.ValueObjects;
using Domain.Core.Exceptions;

namespace Domain.ResearchProjects.Entities
{
    public partial class ResearchProject
    {
        /// <summary>
        /// Class <c>ResearchProject</c> Models a Research Project.
        /// </summary>
        public ResearchProjectId Id { get; set; }
        public String Name { get; set; }
        public String? Description { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public byte[]? Image;
        public Group? Group{ get; set; }
        public Person? MainResearcher { get; set; }
        public List<Person> People { get; set; }
        public List<Collaborate> Collaborates { get; set; }
        public List<Publication> Publications { get; set; }
        public List<ResearchArea> ResearchAreas { get; set; }
        public List<Thesis> Theses { get; set; }

        /// <summary>
        /// Research Project class default constructor.
        /// </summary>
        public ResearchProject()
        {
            Id = null!;
            Name = null!;
            Start_date = DateTime.Today;
            End_date = DateTime.Today;
            Description = "";
            Image = null;
            Group = null!;
            People = new List<Person>();
            Publications = null!;
            ResearchAreas = null!;
            Theses = null!;
            Collaborates = null!;
            MainResearcher = null!;
        }

        /// <summary>
        /// Research Project class parameterized constructor.
        /// </summary>
        /// <param name="Id">The id of the Research Project</param>
        /// <param name="name">The name of the Research Project</param>
        /// <param name="Start_date">The start date of the Research Project</param>
        /// <param name="Start_date">The end date of the Research Project</param>
        /// <param name="description">The description of the Research Project</param>
        /// <param name="Group">An instance of Group</param>
        /// /// <param name="People">An instance of People</param>
        /// /// <param name="Publications">An instance of Publication</param>
        /// /// <param name="_researchAreas">An instance of Research Areas</param>
        public ResearchProject(ResearchProjectId id, String name, DateTime start_date, DateTime end_date, 
            string description, byte[]? image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Start_date = start_date;
            End_date = end_date;
            People = new List<Person>();
            Publications = new List<Publication>();
            ResearchAreas = new List<ResearchArea>();
            Theses = new List<Thesis>();
            Collaborates = new List<Collaborate>();
        }

        public bool AddCollab(Collaborate collab)
        {
            Collaborates.Add(collab);
            return true;
        }

        /// <summary>
        /// AddThesis. Adds a thesis to list of theses associated to a project
        /// </summary>
        /// <param name="thesis">The thesis to be added</param>
        public void AddThesis(Thesis thesis)
        {
            Theses.Add(thesis);
        }

        /// <summary>
        /// DeleteThesis. Remove a thesis from a list of theses associated to a project
        /// </summary>
        /// <param name="thesis">The thesis to be deleted</param>
        public void DeleteThesis(Thesis thesis)
        {
            if (Theses.Exists(t => t == thesis))
            {
                Theses.Remove(thesis);
            }
        }

        public bool AddPublication(Publication publication)
        {

            Publications.Add(publication);
            return true;

        }
        public void DeletePublication(Publication publication)
        {
            if (Publications.Exists(p => p == publication))
            {
                Publications.Remove(publication);
            }
        }

        /// <summary>
        /// Method that remove a specific area of a project.
        /// </summary>
        /// <param name="area">The instance of the area to remove</param>
        public void RemoveResearchArea(ResearchArea area)
        {
            if (ResearchAreas.Exists(p => p == area))
            {
                ResearchAreas.Remove(area);
            }
        }
    }
}

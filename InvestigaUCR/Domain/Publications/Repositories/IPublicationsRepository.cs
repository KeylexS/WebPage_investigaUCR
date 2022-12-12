/*
    US ID: PIIB22II02-317
    US name: HT-PB-1.4 Base publication, DOI, authors and title
    Technical Task Resolved: PIIB22II02-464 Implement Publications Repository in Domain
*/
using Domain.Publications.Entities;
using Domain.ResearchProjects.Entities;
using Domain.ResearchGroups.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Publications.Entities
{
    public interface IPublicationsRepository
    {
        Task<Publication?> GetByDOIAsync(string DOI);
        Task<IEnumerable<Publication>> GetAllAsync();
        Task SavePublication(Publication publication);

		//PIIB22II02-897 HT-PB-3.9 Show related groups
		Task<IEnumerable<GroupDTO?>> GetGroupByDOI(string? DOI);
        Task SaveAsync(Publication publication);
        Task DeletePublication(Publication publication);
    }
}
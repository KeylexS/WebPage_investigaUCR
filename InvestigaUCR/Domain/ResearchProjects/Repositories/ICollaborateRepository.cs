using Domain.ResearchProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResearchProjects.Repositories
{
    public interface ICollaborateRepository
    {
        Task<IEnumerable<Collaborate>> GetAllCollabsAsync();
        Task SaveCollab(Collaborate collab);
        Task DeleteCollab(Collaborate collab);
        Task UpdateCollab(Collaborate collab);
    }
}

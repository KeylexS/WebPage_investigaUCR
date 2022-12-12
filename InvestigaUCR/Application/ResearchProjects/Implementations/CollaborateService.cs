using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResearchProjects.Implementations
{
    internal class CollaborateService : ICollaborateService
    {
        private readonly ICollaborateRepository _collabRepository;
        public CollaborateService(ICollaborateRepository collabRepository)
        {
            _collabRepository = collabRepository;
        }

        public async Task<IEnumerable<Collaborate>> GetAllCollabsAsync()
        {
            return await _collabRepository.GetAllCollabsAsync();
        }

        public async Task SaveCollab(Collaborate collab)
        {
            await _collabRepository.SaveCollab(collab);
        }

        public async Task DeleteCollab(Collaborate collab)
        {
            await _collabRepository.DeleteCollab(collab);
        }

        public async Task UpdateCollab(Collaborate collab)
        {
            await _collabRepository.UpdateCollab(collab);
        }
    }
}

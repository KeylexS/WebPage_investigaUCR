using Domain.Core.Repositories;
using Domain.ResearchProjects.Entities;
using Domain.ResearchProjects.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Infrastructure.ResearchProjects.Repositories
{
    internal class CollaborateRepository : ICollaborateRepository
    {
        private readonly GeneralDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public CollaborateRepository(GeneralDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<Collaborate>> GetAllCollabsAsync()
        {
            return await _dbContext.Collaborates.Include(x => x.ResearchProject).Include(x => x.Person).ToListAsync();
        }

        public async Task SaveCollab(Collaborate collab)
        {
            var aux = _dbContext.ResearchProject.FirstOrDefault(x => x.Id == collab.ResearchProjectsId);
            var ret = aux!.AddCollab(collab);
            if (ret)
            {
                _dbContext.Update(aux);
                _dbContext.Entry(collab).State = EntityState.Detached;
                await _dbContext.SaveEntitiesAsync();
            }
        }

        public Task DeleteCollab(Collaborate collab)
        {
            _dbContext.Remove(collab);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateCollab(Collaborate collab)
        {
            _dbContext.Update(collab);
            _dbContext.SaveChanges();
            Debug.WriteLine("shejed");
            return Task.CompletedTask;
        }
    }
}

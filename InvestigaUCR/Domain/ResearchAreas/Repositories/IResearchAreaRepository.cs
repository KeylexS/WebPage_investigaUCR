using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ResearchAreas.Entities;

namespace Domain.ResearchAreas.Repositories
{
    public interface IResearchAreasRepository
    {
        Task<ResearchArea?> GetByIdAsync(string id);
        Task<IEnumerable<ResearchArea>> GetAllAsync();

    }
}

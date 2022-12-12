using Domain.Publications.Entities;
using Domain.Theses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Theses.Entities
{
    public interface IThesesRepository
    {
        Task<Thesis?> GetByIdAsync(int Id);
        Task<IEnumerable<Thesis>> GetAllAsync();
    }
}
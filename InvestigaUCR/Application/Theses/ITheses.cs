using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Publications.Entities;
using Domain.Theses.Entities;

namespace Application.Theses
{
    public interface ITheses
    {
        Task<IEnumerable<Thesis>> GetThesesAsync();
        Task<Thesis> GetThesisByIdAsync(int Id);

        IEnumerable<Thesis> GetFilteredTheses(string text, IEnumerable<Thesis> thesis);
    }
}

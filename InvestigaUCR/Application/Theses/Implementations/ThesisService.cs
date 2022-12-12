using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Shared.StringManipulation.Implementations;
using Domain.Publications.Entities;
using Domain.Shared;
using Domain.Theses.Entities;


namespace Application.Theses.Implementations
{
    internal class ThesisService : ITheses
    {
        private readonly IThesesRepository _thesesRepository;

        public ThesisService(IThesesRepository thesesRepository)
        {
            _thesesRepository = thesesRepository;
        }

        public async Task<IEnumerable<Thesis>> GetThesesAsync()
        {
            return await _thesesRepository.GetAllAsync();
        }

        public async Task<Thesis> GetThesisByIdAsync(int Id)
        {
            return await _thesesRepository.GetByIdAsync(Id);
        }
        public IEnumerable<Thesis> GetFilteredTheses(string searchText, IEnumerable<Thesis> theses)
        {
            StringManipulationService stringManipulation = new StringManipulationService();
            return theses.ToList()
            .Where(thesis =>
                thesis.Title.ToLower().Contains(searchText.ToLower())
                || thesis._Type.ToLower().Contains(searchText.ToLower())
                || thesis.Description != null && thesis.Description.ToLower().Contains(searchText.ToLower())
                || thesis._Date.ToString().ToLower().Contains(searchText.ToLower())
                || stringManipulation.standarizeText(thesis.Title.ToLower()).Contains(searchText.ToLower()))
            .ToList();
        }
    }
}
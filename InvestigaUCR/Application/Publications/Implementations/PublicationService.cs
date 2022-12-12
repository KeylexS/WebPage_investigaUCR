/*
    US ID: PIIB22II02-317
    US name: HT-PB-1.4 Base publication, DOI, authors and title
    Technical Task Resolved: PIIB22II02-466 Implement Application layer for publications
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Publications.Entities;
using Domain.ResearchProjects.Repositories;
using Domain.Shared;
using Application.Shared.StringManipulation.Implementations;
using Domain.ResearchGroups.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchProjects.Entities;

namespace Application.Publications.Implementations
{
    public class PublicationService : IPublications
    {
        private readonly IPublicationsRepository _publicationsRepository;

        public PublicationService(IPublicationsRepository publicationsRepository)
        {
            _publicationsRepository = publicationsRepository;
        }

        public async Task<IEnumerable<Publication>> GetPublicationsAsync() { 
            return await _publicationsRepository.GetAllAsync();
        }

        public async Task<Publication> GetPublicationByDOIAsync(string DOI)
        {
            return await _publicationsRepository.GetByDOIAsync(DOI);
        }
        public IEnumerable<Publication> GetFilteredPublications(string text, IEnumerable<Publication> publications)
        {
            StringManipulationService stringManipulation = new StringManipulationService();
            return publications.ToList()
            .Where(publication =>
                publication.Name.ToLower().Contains(text.ToLower())
                || publication.Abstract.ToLower().Contains(text.ToLower())
                || publication._Date.ToString().ToLower().Contains(text.ToLower())
                || publication.Reference.ToLower().Contains(text.ToLower())
                || publication.Type.ToLower().Contains(text.ToLower())
                ||stringManipulation.standarizeText(publication.Name.ToLower()).Contains(text.ToLower()))
            .ToList();
        }
        public async Task SavePublication(Publication publication)
        {
            publication.Group._publications.Add(publication);
            await _publicationsRepository.SavePublication(publication);
        }

		public async Task<IEnumerable<GroupDTO?>> GetGroupByDOI(string? DOI)
		{
			return await _publicationsRepository.GetGroupByDOI(DOI);
		}
        public async Task SavePublicationName(Publication publication, String name)
        {
            publication.Name = name;
            await _publicationsRepository.SaveAsync(publication);
        }
        public async Task SavePublicationType(Publication publication, String type)
        {
            publication.Type = type;
            await _publicationsRepository.SaveAsync(publication);
        }
        public async Task SavePublicationDate(Publication publication, DateTime date)
        {
            publication._Date = date;
            await _publicationsRepository.SaveAsync(publication);
        }
        public async Task SavePublicationAbstract(Publication publication, String _abstract)
        {
            publication.Abstract = _abstract;
            await _publicationsRepository.SaveAsync(publication);
        }
        public async Task SavePublicationReference(Publication publication, String reference)
        {
            publication.Reference = reference;
            await _publicationsRepository.SaveAsync(publication);
        }
        public async Task DeletePublication(Publication publication)
        {
            await _publicationsRepository.DeletePublication(publication);
        }
        public async Task ChangeVisibility(Publication publication)
        {
            publication.Visibility = 0;
            await _publicationsRepository.SaveAsync(publication);
        }
    }
}

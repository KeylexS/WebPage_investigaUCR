using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Publications.Entities;
using Domain.ResearchGroups.DTOs;
using Domain.ResearchGroups.Entities;
using Domain.ResearchProjects.Entities;

namespace Application.Publications
{
    public interface IPublications
    {
		/// <summary>
		/// Service to get all Publications
		/// </summary>
		/// <returns>The list of publications</returns>
		Task<IEnumerable<Publication>> GetPublicationsAsync();

		/// <summary>
		/// Service to get a Publication by its DOI
		/// </summary>
		/// <param name="DOI"></param>
		/// <returns>The param DOI's respective Publication </returns>
		Task<Publication> GetPublicationByDOIAsync(string DOI);

		/// <summary>
		/// Text-based Publication filter
		/// </summary>
		/// <param name="text"></param>
		/// <param name="publications"</param>
		/// <returns>The list of publications containing the text parameter </returns>
		IEnumerable<Publication> GetFilteredPublications(string text, IEnumerable<Publication> publications);

		/// <summary>
		/// Save a newly created publication
		/// </summary>
		/// <param name="publication"></param>
		Task SavePublication(Publication publication);

		//PIIB22II02-897 HT-PB-3.9 Show related groups
		/// <summary>
		/// Service to get a Publication's group list
		/// </summary>
		/// <param name="DOI"></param>
		/// <returns>The param DOI's respective list of groups</returns>
		Task<IEnumerable<GroupDTO?>> GetGroupByDOI(string? DOI);

		Task SavePublicationName(Publication publication, String name);

        Task SavePublicationType(Publication publication, String type);

		Task SavePublicationDate(Publication publication, DateTime date);

		Task SavePublicationAbstract(Publication publication, String _abstract);

		Task SavePublicationReference(Publication publication, String reference);
		Task DeletePublication(Publication publication);

		Task ChangeVisibility(Publication publication);
    }
}

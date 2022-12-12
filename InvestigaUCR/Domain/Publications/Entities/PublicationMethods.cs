using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Publications.Entities
{
	public partial class Publication
	{
		/// <summary>
		/// Publications method for changing the default date format.
		/// </summary>
		/// <returns>The publication's date formatted to es-ES format</returns>
		public String getFormatedDate()
		{
			return _Date.ToString("dd 'de' MMMM 'del' yyyy", CultureInfo.GetCultureInfo("es-ES"));
		}
	}
}

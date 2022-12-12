using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ResearchProjects.Entities
{
    public partial class ResearchProject
    {
        public String getFormatedStartDate()
        {
            return Start_date.ToString("dd 'de' MMMM 'del' yyyy", CultureInfo.GetCultureInfo("es-ES"));
        }

        public String getFormatedEndDate()
        {
            return End_date.ToString("dd 'de' MMMM 'del' yyyy", CultureInfo.GetCultureInfo("es-ES"));
        }

        public String getStatus()
        {
            string status = "";
            if (End_date < DateTime.Now)
            {
                status = "Finalizado";
            } else if (Start_date <= DateTime.Now && End_date > DateTime.Now)
            {
                status = "En proceso";
            } else if(Start_date > DateTime.Now && End_date > DateTime.Now)
            {
                status = "Pronto a iniciar";
            }
            return status;
            
        }

        public String? getDescription()
        {
            String? newDescription = Description;
            if (Description == null || Description == " " || Description == "")
            {
                newDescription = "No hay descripción disponible";
            }
            return newDescription;
        }

        public String getImageSrc()
        {
            String src;
            if (Image != null)
            {
                src = "data:image / bmp; base64," + @Convert.ToBase64String(Image);
            }
            else
            {
                src = "/images/DefaultImages/researchProject.jpg";
            }
            return src;
        }
    }
}

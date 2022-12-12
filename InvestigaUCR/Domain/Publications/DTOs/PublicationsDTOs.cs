using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User story; HT-PB-1.4 & TT: PIIB22II02-808 Create Publications DTOs 
namespace Domain.Publications.DTOs
{
    public class PublicationsDTOs
    {
        public string Name { get; }
        public string DOI { get; set; }
        public byte Visibility { get; }
        public string Type { get; }
        public string Publisher_name { get; }
        public string Abstract { get; }
        public string Reference { get; }
        public DateTime _Date { get; }

        public PublicationsDTOs(string doi, string name, byte visibility,
                   string type, string publisherName, string abs,
                   string reference, DateTime date)
        {
            DOI = doi;
            Name = name;
            Visibility = visibility;
            Type = type;
            Publisher_name = publisherName;
            Abstract = abs;
            Reference = reference;
            _Date = date;
        }
    }
}

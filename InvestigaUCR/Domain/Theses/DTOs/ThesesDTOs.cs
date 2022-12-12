using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User story; HT-TS-1.1 & TT: PIIB22II02-809 Create Theses DTOs
namespace Domain.Publications.DTOs
{
    public class ThesesDTOs
    {
        public string Title { get; }
        public string _Type { get; }
        public string? Description { get; }
        public int Id { get; }
        public DateTime _Date { get; }

        public ThesesDTOs(string title, string id_rp,
            string type, int id, DateTime date, string description)
        {
            Title = title;
            _Type = type;
            Description = description;
            Id = id;
            _Date = date;
        }
    }
}

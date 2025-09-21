using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerApi
{
    public class Time
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public int TitlesBrazil { get; set; }
        public int TitlesInternacionais { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models
{
    public class CityCountyData
    {
        [Key]
        public int RegionNumber { get; set; } 
        public string Abbreviation { get; set; }
        public string County { get; set; }
        public string? City { get; set; } 
    }
}

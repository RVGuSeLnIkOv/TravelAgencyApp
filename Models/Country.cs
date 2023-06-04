using System.ComponentModel.DataAnnotations;

namespace TravelAgencyApp.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}

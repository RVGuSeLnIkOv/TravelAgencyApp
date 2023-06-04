using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        int GetIdCountry(string countryName);
    }
}

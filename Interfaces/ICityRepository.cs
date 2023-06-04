using TravelAgencyApp.Models;

namespace TravelAgencyApp.Interfaces
{
    public interface ICityRepository
    {
        ICollection<City> GetCities(int idCountry);
        int GetIdCity(string cityName);
    }
}

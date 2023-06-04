using TravelAgencyApp.Data;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.CountryName).ToList();
        }

        public int GetIdCountry(string countryName)
        {
            var country = _context.Countries.Where(c => c.CountryName == countryName).FirstOrDefault();

            if (country == null)
                return -1;

            return country.IdCountry;
        }
    }
}

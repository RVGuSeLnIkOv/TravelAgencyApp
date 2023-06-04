using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;
using TravelAgencyApp.Repository;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository,
            ICityRepository cityRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet("api/Country/Countries")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (countries.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("api/Country/{countryName}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetIdCountry(string countryName)
        {
            var id = _countryRepository.GetIdCountry(countryName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(id);
        }

        [HttpGet("api/Country/{idCountry}/Cities")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<City>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCities(int idCountry)
        {
            var cities = _mapper.Map<List<CityDto>>(_cityRepository.GetCities(idCountry));

            if (cities.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cities);
        }
    }
}

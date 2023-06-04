using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly IResidenceRepository _residenceRepository;
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityRepository,
            IResidenceRepository residenceRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        [HttpGet("api/City/{cityName}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetIdCity(string cityName)
        {
            var id = _cityRepository.GetIdCity(cityName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(id);
        }

        [HttpGet("api/City/{idCity}/Residences")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Residence>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetResidences(int idCity)
        {
            var residences = _mapper.Map<List<ResidenceDto>>(_residenceRepository.GetResidences(idCity));

            if (residences.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(residences);
        }
    }
}

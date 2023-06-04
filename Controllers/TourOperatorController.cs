using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    public class TourOperatorController : Controller
    {
        private readonly ITourOperatorRepository _tourOperatorRepository;
        private readonly IMapper _mapper;

        public TourOperatorController(ITourOperatorRepository tourOperatorRepository, IMapper mapper)
        {
            _tourOperatorRepository = tourOperatorRepository;
            _mapper = mapper;
        }

        [HttpGet("api/TourOperator/TourOperators")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TourOperator>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetTourOperators()
        {
            var tourOperators = _mapper.Map<List<TourOperatorDto>>(_tourOperatorRepository.GetTourOperators());

            if (tourOperators.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tourOperators);
        }

        [HttpGet("api/TourOperator/{tourOperatorName}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetIdTourOperator(string tourOperatorName)
        {
            var id = _tourOperatorRepository.GetIdTourOperator(tourOperatorName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(id);
        }
    }
}

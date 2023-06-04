using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    public class ResidenceController : Controller
    {
        private readonly IResidenceRepository _residenceRepository;
        private readonly IMapper _mapper;

        public ResidenceController(IResidenceRepository residenceRepository, IMapper mapper)
        {
            _residenceRepository = residenceRepository;
            _mapper = mapper;
        }

        [HttpGet("api/Residence/{residenceName}/{stars}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetIdResidence(string residenceName, string stars)
        {
            var id = _residenceRepository.GetIdResidence(residenceName, stars);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(id);
        }
    }
}

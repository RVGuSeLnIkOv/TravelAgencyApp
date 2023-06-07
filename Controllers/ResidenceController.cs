using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;
using TravelAgencyApp.Repository;

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

        [HttpGet("api/Residence/{id}")]
        [ProducesResponseType(200, Type = typeof(Residence))]
        [ProducesResponseType(400)]
        public IActionResult GetResidence(int id)
        {
            var residence = _mapper.Map<ResidenceDto>(_residenceRepository.GetResidence(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(residence);
        }
    }
}

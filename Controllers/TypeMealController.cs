using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgencyApp.Dto;
using TravelAgencyApp.Interfaces;
using TravelAgencyApp.Models;
using TravelAgencyApp.Repository;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    public class TypeMealController : Controller
    {
        private readonly ITypeMealRepository _typeMealRepository;
        private readonly IMapper _mapper;

        public TypeMealController(ITypeMealRepository typeMealRepository, IMapper mapper)
        {
            _typeMealRepository = typeMealRepository;
            _mapper = mapper;
        }

        [HttpGet("api/TypeMeal/TypesMeal")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TypeMeal>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetTypeMeal()
        {
            var typesMeal = _mapper.Map<List<TypeMealDto>>(_typeMealRepository.GetTypesMeal());

            if (typesMeal.Count == 0)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(typesMeal);
        }

        [HttpGet("api/TypeMeal/{typeMealName}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetIdTypeMeal(string typeMealName)
        {
            var id = _typeMealRepository.GetIdTypeMeal(typeMealName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(id);
        }
    }
}

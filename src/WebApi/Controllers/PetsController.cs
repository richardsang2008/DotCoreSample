using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using DataModels.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    #region snippet_PetsController
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IService _repository;

        public PetsController(IService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAllAsync()
        {
            return await _repository.GetPetsAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Pet>> GetByIdAsync(int id)
        {
            var pet = await _repository.GetPetAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Pet>> CreateAsync(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = pet.Id }, pet);
        }
    }
    #endregion        
    
}
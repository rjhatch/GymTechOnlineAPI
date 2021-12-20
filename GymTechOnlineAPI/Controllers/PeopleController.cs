using GymTechOnlineAPI.Models;
using GymTechOnlineAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymTechOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService peopleService) =>
            _peopleService = peopleService;

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<List<Person>> Get() => await _peopleService.GetAsync();

        // GET api/<PeopleController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Person>> Get(string id)
        {
            var person = await _peopleService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            return person;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<IActionResult> Post(Person newPerson)
        {
            await _peopleService.CreateAsync(newPerson);

            return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, newPerson);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Person updatedPerson)
        {
            var person = await _peopleService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            updatedPerson.Id = person.Id;

            await _peopleService.UpdateAsync(id, updatedPerson);

            return NoContent();
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var person = await _peopleService.GetAsync(id);

            if (person is null)
            {
                return NotFound();
            }

            await _peopleService.RemoveAsync(person.Id);

            return NoContent();
        }
    }
}

using GymTechOnlineAPI.Models;
using GymTechOnlineAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymTechOnlineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService) =>
            _scheduleService = scheduleService;

        // GET: api/<ScheduleController>
        [HttpGet]
        public async Task<List<Session>> Get() => await _scheduleService.GetAsync();

        // GET api/<ScheduleController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Session>> Get(string id)
        {
            var session = await _scheduleService.GetAsync(id);

            if (session is null)
            {
                return NotFound();
            }

            return session;
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public async Task<IActionResult> Post(Session newSession)
        {
            await _scheduleService.CreateAsync(newSession);

            return CreatedAtAction(nameof(Get), new { id = newSession.Id }, newSession);
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Session updatedSession)
        {
            var session = await _scheduleService.GetAsync(id);

            if (session is null)
            {
                return NotFound();
            }

            updatedSession.Id = session.Id;

            await _scheduleService.UpdateAsync(id, updatedSession);

            return NoContent();
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var session = await _scheduleService.GetAsync(id);

            if (session is null)
            {
                return NotFound();
            }

            await _scheduleService.RemoveAsync(session.Id);

            return NoContent();
        }
    }
}

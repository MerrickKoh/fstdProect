using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryPRojectFull.Server.Data;
using FoodDeliveryPRojectFull.Shared.Domains;
using FoodDeliveryPRojectFull.Server.IRepository;

namespace FoodDeliveryPRojectFull.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {
            var Events = await _unitOfWork.Events.GetAll();
            return Ok(Events);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var Event = await _unitOfWork.Events.Get(q => q.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            return Ok(Event);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Events Event)
        {
            if (id != Event.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Events.Update(Event);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Events>> PostEvent(Events Event)
        {
            await _unitOfWork.Events.Insert(Event);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEvent", new { id = Event.Id }, Event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var Event = await _unitOfWork.Events.Get(q => q.Id == id);
            if (Event == null)
            {
                return NotFound();
            }

            await _unitOfWork.Events.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> EventExists(int id)
        {
            var Event = await _unitOfWork.Events.Get(q => q.Id == id);
            return Event != null;
        }
    }
}

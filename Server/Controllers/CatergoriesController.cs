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
    public class CatergoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatergoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Catergories
        [HttpGet]
        public async Task<IActionResult>GetCatergory()
        {
         
            var catergories = await _unitOfWork.Catergories.GetAll();
            return Ok(catergories);
        }

        // GET: api/Catergories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatergory(int id)
        {
            
            var catergory = await _unitOfWork.Catergories.Get(q => q.Id == id);

            if (catergory == null)
            {
                return NotFound();
            }

            return Ok(catergory);
        }

        // PUT: api/Catergories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatergory(int id, Catergory catergory)
        {
            if (id != catergory.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Catergories.Update(catergory);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CatergoryExists(id))
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

        // POST: api/Catergories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Catergory>> PostCatergory(Catergory catergory)
        {
            await _unitOfWork.Catergories.Insert(catergory);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCatergory", new { id = catergory.Id }, catergory);
        }

        // DELETE: api/Catergories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatergory(int id)
        {
            var catergory = await _unitOfWork.Catergories.Get(q => q.Id == id);
            if (catergory == null)
            {
                return NotFound();
            }

            await _unitOfWork.Catergories.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CatergoryExists(int id)
        {
            var catergory = await _unitOfWork.Catergories.Get(q => q.Id == id);
            return catergory != null;
        }
    }
}

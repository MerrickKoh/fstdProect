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
    public class FoodsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FoodsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task<IActionResult> GetFood()
        {
            var Foods = await _unitOfWork.Foods.GetAll(includes: q => q.Include(x =>x.Catergory).Include(x => x.Events));
            return Ok(Foods);
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var Food = await _unitOfWork.Foods.Get(q => q.Id == id);

            if (Food == null)
            {
                return NotFound();
            }

            return Ok(Food);
        }

        // PUT: api/Foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food Food)
        {
            if (id != Food.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Foods.Update(Food);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FoodExists(id))
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

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food Food)
        {
            await _unitOfWork.Foods.Insert(Food);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFood", new { id = Food.Id }, Food);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var Food = await _unitOfWork.Foods.Get(q => q.Id == id);
            if (Food == null)
            {
                return NotFound();
            }

            await _unitOfWork.Foods.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> FoodExists(int id)
        {
            var Food = await _unitOfWork.Foods.Get(q => q.Id == id);
            return Food != null;
        }
    }
}

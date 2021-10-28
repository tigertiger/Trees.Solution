using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tree.Models;


namespace Tree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly TreesContext _db;
        public PlantsController(TreesContext db)
        {
            _db = db;
        }

        //Get api/plants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> Get(string strain, string type, string farm)
        {
          var query = _db.Plants.AsQueryable();

          if (strain != null)
          {
            query = query.Where(entry => entry.Strain == strain);
          }

          if (type != null)
          {
            query = query.Where(entry => entry.Type == type);
          }

          if (farm != null)
          {
            query = query.Where(entry => entry.Farm == farm);
          }


            return await query.ToListAsync();
        }
        //POST api/plants
        [HttpPost]
        public async Task<ActionResult<Plant>> Post(Plant plant)
        {
            _db.Plants.Add(plant);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlant), new { id = plant.PlantId }, plant);
        }
        //GET api/plants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _db.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return plant;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, Plant plant)
        {
          if(id != plant.PlantId)
          {
            return BadRequest();
          }

          _db.Entry(plant).State = EntityState.Modified;

          try
          {
            await _db.SaveChangesAsync();
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!PlantExists(id))
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

        //DELETE api/plants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _db.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            _db.Plants.Remove(plant);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        
        private bool PlantExists(int id)
        {
          return _db.Plants.Any(e => e.PlantId == id);
        }
    }
}

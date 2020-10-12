using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureBookController : ControllerBase
    {
        private readonly AppDatabase _context;

        public AdventureBookController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet("GetAdventure")]
        public List<Adventures> GetAdventure()
        {
            try
            {
                var adventures = _context.Adventures.OrderBy(m => m.adventureId).ToList();
                return adventures;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


        }
        [HttpGet("GetAdventureById/{AdventureID}")]
        public Adventures GetAdventureById(int AdventureID)
        {
            try
            {
                var adventures = _context.Adventures.FirstOrDefault(s => s.adventureId == AdventureID);
                return adventures;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        [HttpPost("AddAdventure")]
        public async Task<IActionResult> AddAdventure([FromBody] Adventures adventure)
        {


            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddAdventure", new { id = adventure.adventureId }, adventure);

        }

        [HttpPut("UpdateAdventure")]
        public async Task<IActionResult> UpdateAdventure([FromBody] Adventures adventure)
        {
            try
            {
                var selectedAdventure = _context.Adventures.FirstOrDefault(f => f.adventureId == adventure.adventureId);

                selectedAdventure.adventureName = adventure.adventureName;
                selectedAdventure.adventureDescription = adventure.adventureDescription;
                // selectedAssignment.ChapterID = assignment.ChapterID;

                await _context.SaveChangesAsync();

                return CreatedAtAction("UpdateAdventure", selectedAdventure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [HttpDelete("DeleteAdventure/{AdventureID}")]
        public void DeleteAdventure(int AdventureID)
        {
            try
            {
                var adventure = _context.Adventures.FirstOrDefault(s => s.adventureId == AdventureID);
                _context.Adventures.Remove(adventure);
                _context.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

        }
    }
}

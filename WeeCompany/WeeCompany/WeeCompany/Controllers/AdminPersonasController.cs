using WeeCompany.Data;
using WeeCompany.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeeCompany.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class AdminPersonasController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminPersonasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tblpersonas>>> GetAllpersonasAsync()
        {
            return await _context.Tblpersonas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tblpersonas>> GetPersonaByIdAsync(int id)
        {
            var result = await _context.Tblpersonas.FindAsync(id);
            if (result == null)
                return NotFound("Game not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaAsync(int id)
        {
            var result = await _context.Tblpersonas.FindAsync(id);
            if (result == null)
                return NotFound("Game not found");

            _context.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tblpersonas>> UpdatePersonaAsync(int id, Tblpersonas updateGame)
        {
            var dbGame = await _context.Tblpersonas.FindAsync(id);
            if (dbGame == null)
                return NotFound("Game not found");

            dbGame.Contacto = updateGame.Contacto;
            dbGame.Compania = updateGame.Compania;
            dbGame.Correo = updateGame.Correo;

            await _context.SaveChangesAsync();

            return Ok(dbGame);
        }

        [HttpPost()]
        public async Task<ActionResult<Tblpersonas>> AddPersonaAsync(Tblpersonas newPersona)
        {
            _context.Add(newPersona);
            await _context.SaveChangesAsync();

            return Ok(newPersona);
        }
    }

}

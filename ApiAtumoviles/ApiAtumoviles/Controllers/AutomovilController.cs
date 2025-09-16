using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAutomoviles.Data;
using ApiAutomoviles.Models;

namespace ApiAutomoviles.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutomovilController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutomovilController(AppDbContext context)
        {
            _context = context;
        }
        //Endpoints.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Automovil automovil)
        {
            if (automovil == null)
                return BadRequest("Automóvil inválido.");

            // Validación simple de campos obligatorios
            if (string.IsNullOrEmpty(automovil.Marca) ||
                string.IsNullOrEmpty(automovil.Modelo) ||
                string.IsNullOrEmpty(automovil.Color))
                return BadRequest("Marca, Modelo y Color son obligatorios.");

            _context.Automoviles.Add(automovil);
            await _context.SaveChangesAsync(); // 👈 acá va async

            return CreatedAtAction(nameof(GetById), new { id = automovil.Id }, automovil);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var auto = await _context.Automoviles.FindAsync(id);
            if (auto == null)
                return NotFound($"No se encontró el automóvil con ID {id}.");

            return Ok(auto);
        }

        [HttpGet("chasis/{numeroChasis}")]
        public async Task<IActionResult> GetByChasis(string numeroChasis)
        {
            var auto = await _context.Automoviles
                .FirstOrDefaultAsync(a => a.NumeroChasis == numeroChasis);

            if (auto == null)
                return NotFound($"No se encontró el automóvil con chasis {numeroChasis}.");

            return Ok(auto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autos = await _context.Automoviles.ToListAsync();
            return Ok(autos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Automovil updatedAuto)
        {
            var auto = await _context.Automoviles.FindAsync(id);
            if (auto == null)
                return NotFound($"No se encontró el automóvil con ID {id}.");

            // Actualizar campos permitidos
            auto.Marca = updatedAuto.Marca ?? auto.Marca;
            auto.Modelo = updatedAuto.Modelo ?? auto.Modelo;
            auto.Color = updatedAuto.Color ?? auto.Color;
            auto.Fabricacion = updatedAuto.Fabricacion != 0 ? updatedAuto.Fabricacion : auto.Fabricacion;
            auto.NumeroMotor = updatedAuto.NumeroMotor ?? auto.NumeroMotor;
            auto.NumeroChasis = updatedAuto.NumeroChasis ?? auto.NumeroChasis;

            await _context.SaveChangesAsync();
            return Ok(auto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var auto = await _context.Automoviles.FindAsync(id);
            if (auto == null)
                return NotFound($"No se encontró el automóvil con ID {id}.");

            _context.Automoviles.Remove(auto);
            await _context.SaveChangesAsync();
            return Ok($"Automóvil con ID {id} eliminado correctamente.");
        }

    }
}


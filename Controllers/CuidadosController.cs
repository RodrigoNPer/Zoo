using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Data;
using ZooAPI.Models;

namespace ZooAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuidadosController : ControllerBase
{
    private readonly ZooContext _context;

    public CuidadosController(ZooContext context)
    {
        _context = context;
    }

    // GET: api/cuidados
    [HttpGet]
    public ActionResult<IEnumerable<Cuidado>> Get()
    {
        return Ok(_context.Cuidados.ToList());
    }

    // POST: api/cuidados/{animalId}
    [HttpPost("{animalId}")]
    public IActionResult AssociarCuidado(int animalId, [FromBody] Cuidado cuidado)
    {
        var animal = _context.Animais.Include(a => a.AnimalCuidados).FirstOrDefault(a => a.Id == animalId);

        if (animal == null)
            return NotFound("Animal não encontrado.");

        // Verifica se o cuidado já existe no banco de dados
        var cuidadoExistente = _context.Cuidados.FirstOrDefault(c => c.Nome == cuidado.Nome && c.Frequencia == cuidado.Frequencia);

        if (cuidadoExistente == null)
        {
            // Adiciona o cuidado ao banco de dados se não existir
            _context.Cuidados.Add(cuidado);
            _context.SaveChanges();
            cuidadoExistente = cuidado;
        }

        // Verifica se a associação já existe
        if (animal.AnimalCuidados.Any(ac => ac.CuidadoId == cuidadoExistente.Id))
            return BadRequest("Este cuidado já está associado ao animal.");

        // Cria a associação
        animal.AnimalCuidados.Add(new AnimalCuidado
        {
            AnimalId = animalId,
            CuidadoId = cuidadoExistente.Id
        });

        _context.SaveChanges();

        return Ok("Cuidado associado com sucesso.");
    }
}
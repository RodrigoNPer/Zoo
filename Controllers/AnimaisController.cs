using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Adicionado para o Include
using ZooAPI.Data;
using ZooAPI.Models;

namespace ZooAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimaisController : ControllerBase
{
    private readonly ZooContext _context;

    public AnimaisController(ZooContext context)
    {
        _context = context;
    }

    // GET: api/animais
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get() => Ok(_context.Animais.ToList());

    // GET: api/animais/1
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
        var animal = _context.Animais.Find(id);
        return animal == null ? NotFound() : Ok(animal);
    }
    
    // POST: api/animais
    [HttpPost]
    public ActionResult<Animal> Post(Animal animal)
    {
        if (string.IsNullOrEmpty(animal.Nome))
            return BadRequest("Nome é obrigatório");
        
        _context.Animais.Add(animal);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
    }

    // PUT: api/animais/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, Animal animalAtualizado)
    {
        var animal = _context.Animais.Find(id);
        if (animal == null)
            return NotFound();
        
        animal.Nome = animalAtualizado.Nome;
        animal.Descricao = animalAtualizado.Descricao;
        animal.DataNascimento = animalAtualizado.DataNascimento;
        animal.Especie = animalAtualizado.Especie;
        animal.Habitat = animalAtualizado.Habitat;
        animal.PaisOrigem = animalAtualizado.PaisOrigem;
        
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/animais/1 (VERSÃO SIMPLIFICADA)
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Console.WriteLine($"Tentativa de deletar animal ID: {id}");
        
        var animal = _context.Animais.Find(id);

        if (animal == null)
        {
            Console.WriteLine("Animal não encontrado");
            return NotFound();
        }

        try
        {
            _context.Animais.Remove(animal);
            _context.SaveChanges();
            
            Console.WriteLine("Animal deletado com sucesso");
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO: {ex}");
            return StatusCode(500, new { 
                Message = "Erro ao deletar animal",
                Error = ex.Message
            });
        }
    }

    // POST: api/animais/1/cuidados/2
    [HttpPost("{animalId}/cuidados/{cuidadoId}")]
    public IActionResult AssociarCuidado(int animalId, int cuidadoId)
    {
        var animal = _context.Animais.Include(a => a.AnimalCuidados).FirstOrDefault(a => a.Id == animalId);
        var cuidado = _context.Cuidados.Find(cuidadoId);

        if (animal == null || cuidado == null) return NotFound();

        // Verifica se a associação já existe
        if (animal.AnimalCuidados.Any(ac => ac.CuidadoId == cuidadoId))
            return BadRequest("Este cuidado já está associado ao animal");

        animal.AnimalCuidados.Add(new AnimalCuidado { AnimalId = animalId, CuidadoId = cuidadoId });
        _context.SaveChanges();

        return NoContent();
    }
}
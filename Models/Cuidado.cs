using ZooAPI.Models;
namespace ZooAPI.Models;

public class Cuidado
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Frequencia { get; set; } = string.Empty;

    public List<ZooAPI.Models.AnimalCuidado> AnimalCuidados { get; set; } = new();
}
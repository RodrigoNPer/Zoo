namespace ZooAPI.Models;

/// <summary>
/// Representa a relação N:N entre Animal e Cuidado.
/// </summary>
public class AnimalCuidado
{
    // Chave estrangeira para Animal
    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = null!; // Navegação para Animal

    // Chave estrangeira para Cuidado
    public int CuidadoId { get; set; }
    public Cuidado Cuidado { get; set; } = null!; // Navegação para Cuidado
}
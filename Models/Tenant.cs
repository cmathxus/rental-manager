namespace tdlimoveis.Models
{
  public class Tenant : Person
  {
    public int Id { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public List<Contract> Contracts { get; set; } = new();
  }
}
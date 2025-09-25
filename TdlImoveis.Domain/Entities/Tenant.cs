namespace tdlimoveis.Domain.Entities
{
  public class Tenant : Person
  {
    public int Id { get; set; }
    public DateOnly DataDeNascimento { get; set; }
    public int ContractId { get; set; }
    public Contract Contract { get; set; }
  }
}
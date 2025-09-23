namespace tdlimoveis.Domain.Entities
{
  public class Contract
  {
    public int Id { get; set; }
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFim { get; set; }
    public double ValorAluguel { get; set; }
    public bool StatusContract { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; }

    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
  }
}
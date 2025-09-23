namespace tdlimoveis.Application.DTOs
{
  public class ContractCreateDto
  {
    public DateOnly DataInicio { get; set; }
    public DateOnly DataFim { get; set; }
    public double ValorAluguel { get; set; }
    public bool StatusContract { get; set; }
    public int PropertyId { get; set; }
    public int TenantId{ get; set; }
  }
}
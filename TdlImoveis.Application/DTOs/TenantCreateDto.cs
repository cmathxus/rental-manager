using tdlimoveis.ValueObjects;

namespace tdlimoveis.Application.DTOs
{
  public class TenantCreateDto
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string Phone { get; set; }
    public DateOnly DataDeNascimento { get; set; }
  }
}
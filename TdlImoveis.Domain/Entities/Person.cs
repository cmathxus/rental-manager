using tdlimoveis.ValueObjects;

namespace tdlimoveis.Domain.Entities
{
  public abstract class Person
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string DocumentNumber { get; set; }
    public string Phone { get; set; }
  }
}
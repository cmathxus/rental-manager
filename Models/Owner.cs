namespace tdlimoveis.Models
{
  public class Owner : Person
  {
    public int Id { get; set; }
    public string BankAccount { get; set; }

    public List<Property> Properties { get; set; } = new();
  }
}
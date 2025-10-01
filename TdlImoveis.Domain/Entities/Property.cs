namespace tdlimoveis.Domain.Entities
{
  public class Property
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Neighboorhood { get; set; }
    public string Type { get; set; }
    public double RentalValue { get; set; }
    public DateOnly InsuranceExpiry { get; set; }
    public bool Status { get; set; }

    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }

    public List<Contract> Contracts { get; set; } = new();
  }
}
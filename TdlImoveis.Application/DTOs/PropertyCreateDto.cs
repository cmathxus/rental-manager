namespace tdlimoveis.Application.DTOs
{
  public class PropertyCreateDto
  {
    public string Address { get; set; }
    public string Type { get; set; }
    public string PostalCode { get; set; }
    public string Neighboorhood { get; set; }
    public double RentalValue { get; set; }
    public DateOnly InsuranceExpiry { get; set; }
    public bool Status { get; set; }
    public int OwnerId { get; set; }
  }
}
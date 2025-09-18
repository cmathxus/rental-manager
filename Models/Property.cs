using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace tdlimoveis.Models
{
  public class Property
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public double RentalValue { get; set; }
    public DateOnly InsuranceExpiry { get; set; }
    public bool Status { get; set; }

    public int OwnerId { get; set; }
    [JsonIgnore]
    public Owner? Owner { get; set; }

    public List<Contract> Contracts { get; set; } = new();
  }
}
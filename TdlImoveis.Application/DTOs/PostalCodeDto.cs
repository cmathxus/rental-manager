using System.Text.Json.Serialization;

namespace tdlimoveis.Application.DTOs;

public class PostalCodeDto
{
    [JsonPropertyName("logradouro")]
    public string Logradouro { get; set; }
    
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; }
    
}
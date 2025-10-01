namespace tdlimoveis.ValueObjects
{
  public class DocumentNumber
  {
    public string Number { get; set; }
    
    // Construtor vazio necessário pro EF Core
    protected DocumentNumber() { }

    public DocumentNumber(string number)
    {
      if (string.IsNullOrWhiteSpace(number)  || number.Length > 14)
        throw new Exception("Documento inválido!");

      Number = number;
    }
  }
}
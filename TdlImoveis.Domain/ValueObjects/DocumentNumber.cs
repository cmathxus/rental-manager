namespace tdlimoveis.ValueObjects
{
  public class DocumentNumber
  {
    public string Number { get; }

    public DocumentNumber(string number)
    {
      if (string.IsNullOrWhiteSpace(number))
        throw new Exception("Documento inválido!");

      Number = number;
    }
  }
}
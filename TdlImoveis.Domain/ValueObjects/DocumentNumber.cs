namespace tdlimoveis.ValueObjects
{
  public class DocumentNumber
  {
    public string Number { get; }

    public DocumentNumber(string number)
    {
      if (string.IsNullOrWhiteSpace(number)  || number.Length < 11)
        throw new Exception("Documento inválido!");

      Number = number;
    }
  }
}
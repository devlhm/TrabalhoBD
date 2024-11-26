namespace Api.Presentation.Requests;
public record SellRequest(
    int ProductId,
    int Quantity,
    string Cpf);
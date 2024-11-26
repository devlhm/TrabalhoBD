using Api.Domain.Enums;

namespace Api.Presentation.Requests;

public record GetClientInvoicesByStatusRequest(
        string Cpf,
        EInvoiceStatus Status
    );
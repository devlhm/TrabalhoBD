using Api.Domain.Enums;

namespace Api.Application.Requests;

public record UpdateInvoiceStatusRequest(
    string Cpf,
    EInvoiceStatus Status
    );
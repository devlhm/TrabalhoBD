using Api.Domain.Enums;

namespace Api.Application.Requests;

public record GetClientInvoicesByStatusRequest(
        string Cpf,
        EInvoiceStatus Status
    );
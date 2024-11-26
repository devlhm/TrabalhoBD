using Api.Domain.Enums;

namespace Api.Presentation.Requests;

public record UpdateInvoiceStatusRequest(
    int InvoiceId,
    EInvoiceStatus Status
    );
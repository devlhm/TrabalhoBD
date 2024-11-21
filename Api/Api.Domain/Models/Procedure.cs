namespace Api.Domain.Models;

public record Procedure
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string ProfessionalType { get; set; }
    public string ProfessionalCPF { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public int InvoiceId { get; set; }
    public string ClientCPF { get; set; }

    public Procedure(int id, string nome, decimal valor, string tipo_profissional, DateTime data, TimeSpan hora, string cpf_profissional, int id_fatura, string cpf_cliente)
    {
        Id = id;
        Name = nome;
        Value = valor;
        ProfessionalType = tipo_profissional;
        ProfessionalCPF = cpf_profissional;
        Date = data;
        Time = hora;
        InvoiceId = id_fatura;
        ClientCPF = cpf_cliente;
    }
}

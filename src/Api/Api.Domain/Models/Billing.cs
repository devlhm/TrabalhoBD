namespace Api.Domain.Models
{
    public class Billing
    {
        public decimal? Total { get; set; }
        
        public decimal? ProductTotal { get; set; }
        public decimal? ProcedureTotal { get; set; }
        public List<MonthBilling> ProductBilling { get; set; } = [];
        public List<MonthBilling> ProcedureBilling { get; set; } = [];
    }

    public class MonthBilling
    {
        public DateTime Month { get; set; }
        public decimal Total { get; set; }
    }
}
namespace Api.Application;

using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Interface.Repository;
using Api.Application.Interface.Service;
using Api.Domain.Models;

public class BillingService(IProductService productService, IProcedureService procedureService) : IBillingService
{
    public async Task<Billing> GetLastYearBilling()
    {
        var productBilling = await productService.GetLastYearBilling();
        var procedureBilling = await procedureService.GetLastYearBilling();

        var billing = new Billing
        {
            ProductBilling = productBilling,
            ProcedureBilling = procedureBilling,
            ProductTotal = productBilling.Sum(x => x.Total),
            ProcedureTotal = procedureBilling.Sum(x => x.Total),
        };

        billing.Total = billing.ProductTotal + billing.ProcedureTotal;

        return billing;
    }
}
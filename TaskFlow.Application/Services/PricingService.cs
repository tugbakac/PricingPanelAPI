using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain;

namespace TaskFlow.Application.Services
{
    public class PricingService : IPricingService
    {
        private readonly ICommissionService _commissionService;

        public PricingService(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }

        public Product Calculate(Product product)
        {
            var rate = _commissionService.GetRate(product.Category);

            var commission = product.BaseCost * rate;
            var total = product.BaseCost + commission;
            var vat = total * 0.2m;
            var final = total + vat;

            product.CommissionAmount = commission;
            product.VatAmount = vat;
            product.FinalPrice = final;
            product.ProfitMargin = ((final - product.BaseCost) / product.BaseCost) * 100;

            return product;
        }
    }
}

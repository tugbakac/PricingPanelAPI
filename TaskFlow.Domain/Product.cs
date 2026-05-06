using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string MerchantId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal BaseCost { get; set; }

        public decimal CommissionAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal ProfitMargin { get; set; }
    }
}

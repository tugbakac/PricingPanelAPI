using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Infrastructure.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly Dictionary<string, decimal> _rates = new()
    {
        { "Elektronik", 0.08m },
        { "Tekstil", 0.15m },
        { "Kozmetik", 0.12m },
        { "Ev & Yaşam", 0.10m }
    };

        public decimal GetRate(string category)
        {
            if (!_rates.ContainsKey(category))
                throw new Exception("Kategori bulunamadı");

            return _rates[category];
        }
    }
}

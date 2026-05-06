using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;

namespace TaskFlow.Application.Interfaces.Services
{
    public interface IPricingService
    {
        public Product Calculate(Product product);
    }
}

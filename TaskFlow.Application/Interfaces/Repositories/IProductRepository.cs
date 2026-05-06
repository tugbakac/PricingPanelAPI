using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain;

namespace TaskFlow.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task AddAsync(Product product);
        public Task<List<Product>> GetByMerchantIdAsync(string merchantId);

    }
}

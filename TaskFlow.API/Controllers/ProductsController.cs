using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.Product;
using TaskFlow.Application.Interfaces.Repositories;
using TaskFlow.Application.Interfaces.Services;
using TaskFlow.Domain;

namespace TaskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IPricingService _pricingService;
        private readonly IProductRepository _repository;

        public ProductsController(IPricingService pricingService, IProductRepository repository)
        {
            _pricingService = pricingService;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var merchantId = HttpContext.Items["MerchantId"]?.ToString();

            var product = new Product
            {
                Id = Guid.NewGuid(),
                MerchantId = merchantId,
                ProductName = dto.ProductName,
                Category = dto.Category,
                BaseCost = dto.BaseCost
            };

            product = _pricingService.Calculate(product);

            await _repository.AddAsync(product);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var merchantId = HttpContext.Items["MerchantId"]?.ToString();

            var products = await _repository.GetByMerchantIdAsync(merchantId);

            return Ok(products);
        }
    }
}

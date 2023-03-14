using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var products = await _productRepository.FindAll();
            if (products is null)
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
        {
            if (vo is null)
                return BadRequest();
            var product = await _productRepository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
        {
            if (vo is null)
                return BadRequest();
            var product = await _productRepository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (status)
                return Ok(status);
            return BadRequest();
        }


    }
}

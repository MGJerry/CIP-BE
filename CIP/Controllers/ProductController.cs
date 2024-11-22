using CIP.DTO;
using CIP.Service;
using Microsoft.AspNetCore.Mvc;

namespace CIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("getCustomerById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var response = await _productService.GetProductById(id);
                if (response != null)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequestDTO request)
        {
            try
            {
                var response = await _productService.UpdateProduct(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO request)
        {
            try
            {
                var response = await _productService.CreateProduct(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteCustomer")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var response = await _productService.DeleteProduct(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

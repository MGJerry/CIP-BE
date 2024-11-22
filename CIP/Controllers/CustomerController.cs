using CIP.DTO;
using CIP.Models;
using CIP.Service;
using Microsoft.AspNetCore.Mvc;

namespace CIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await _customerService.GetAllCustomer());
        }

        [HttpGet("getCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var response = await _customerService.GetCustomerById(id);
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


        [HttpPut("updateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRequestDTO request)
        {
            try
            {
                var response = await _customerService.UpdateCustomer(request);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDTO request)
        {
            try
            {
                var response = await _customerService.CreateCustomer(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var response = await _customerService.DeleteCustomer(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}

using CIP.DTO;
using CIP.Service;
using Microsoft.AspNetCore.Mvc;

namespace CIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("getAllTransaction")]
        public async Task<IActionResult> GetAllTransaction()
        {
            return Ok(await _transactionService.GetAllTransaction());
        }

        [HttpGet("getTransactionById")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            try
            {
                var response = await _transactionService.GetTransactionById(id);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("updateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionRequestDTO request)
        {
            try
            {
                var response = await _transactionService.UpdateTransaction(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateDTO request)
        {
            try
            {
                var response = await _transactionService.CreateTransaction(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                var response = await _transactionService.DeleteTransaction(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

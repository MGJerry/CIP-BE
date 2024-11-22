using CIP.DTO;
using CIP.Service;
using Microsoft.AspNetCore.Mvc;

namespace CIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly TransactionDetailService _transactionDetailService;

        public TransactionDetailController(TransactionDetailService transactionDetailService)
        {
            _transactionDetailService = transactionDetailService;
        }

        [HttpGet("getAllTransactionDetail")]
        public async Task<IActionResult> GetAllTransactionDetail()
        {
            return Ok(await _transactionDetailService.GetAllTransactionDetail());
        }

        [HttpGet("getTransactionById")]
        public async Task<IActionResult> GetTransactionDetailById(int id)
        {
            try
            {
                var response = await _transactionDetailService.GetTransactionDetailById(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("updateTransactionDetail")]
        public async Task<IActionResult> UpdateTransactionDetail([FromBody] TransactionDetailDTO request)
        {
            try
            {
                var response = await _transactionDetailService.UpdateTransactionDetail(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createTransactionDetail")]
        public async Task<IActionResult> CreateTransactionDetail([FromBody] TransactionDetailCreateDTO request)
        {
            try
            {
                var response = await _transactionDetailService.CreateTransactionDetail(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteTransactionDetail")]
        public async Task<IActionResult> DeleteTransactionDetail(int id)
        {
            try
            {
                var response = await _transactionDetailService.DeleteTransactionDetail(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

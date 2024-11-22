
using CIP.DTO;
using CIP.Models;
using CIP.Repository;

namespace CIP.Service
{
    public class TransactionDetailService
    {
        private readonly TransactionDetailRepository _repository;
        public TransactionDetailService(
            TransactionDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TransactionDetail>> GetAllTransactionDetail()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TransactionDetail> GetTransactionDetailById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<TransactionDetail> UpdateTransactionDetail(TransactionDetailDTO request)
        {
            TransactionDetail transactionExist = await _repository.GetByIdAsync(request.Id);

            transactionExist.TransactionId = request.TransactionId;
            transactionExist.ProductId = request.ProductId;
            transactionExist.Amount = request.Amount;
            transactionExist.Subtotal = request.Subtotal;

            await _repository.UpdateAsync(transactionExist);
            return transactionExist;
        }

        public async Task<TransactionDetail> CreateTransactionDetail(TransactionDetailCreateDTO request)
        {
            TransactionDetail newTransaction = new TransactionDetail
            {
                TransactionId = request.TransactionId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                Subtotal = request.Subtotal
            };

            await _repository.CreateAsync(newTransaction);
            return newTransaction;
        }

        public async Task<Object?> DeleteTransactionDetail(int id)
        {
            TransactionDetail transactionDetailExist = await _repository.GetByIdAsync(id);
            if (transactionDetailExist != null)
            {
                _repository.RemoveAsync(transactionDetailExist);
                return "Delete success";
            }
            return "Transaction Detail not exist";
        }
    }
}

using CIP.DTO;
using CIP.Models;
using CIP.Repository;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using NuGet.Packaging.Signing;

namespace CIP.Service
{
    public class TransactionService
    {
        private readonly TransactionRepository _repository;
        public TransactionService(
            TransactionRepository repository)
        {
            _repository = repository;
        }



        public async Task<List<Transaction>> GetAllTransaction()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Transaction> GetTransactionById(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<Transaction> UpdateTransaction(TransactionRequestDTO request)
        {
            Transaction transactionExist = await _repository.GetByIdAsync(request.Id);

            transactionExist.Type = request.Type;
            transactionExist.Method = request.Method;
            transactionExist.Total = request.Total;
            await _repository.UpdateAsync(transactionExist);
            return transactionExist;
        }

        public async Task<Transaction> CreateTransaction(TransactionCreateDTO request)
        {
            Transaction newTransaction = new Transaction
            {
                CustomerId = request.CustomerId,
                Type = request.Type,
                TimeStamp = DateTime.Now,
                Method =request.Method,
                Total = request.Total,
            };

            await _repository.CreateAsync(newTransaction);
            return newTransaction;
        }

        public async Task<Object?> DeleteTransaction(int id)
        {
            Transaction transactionExist = await _repository.GetByIdAsync(id);
            if (transactionExist != null)
            {
                _repository.RemoveAsync(transactionExist);
                return "Delete success";
            }
            return "Transaction not exist";
        }
    }
}

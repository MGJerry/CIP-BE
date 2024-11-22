using CIP.Base;
using CIP.Models;
using Microsoft.EntityFrameworkCore;

namespace CIP.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>
    {
        public TransactionRepository()
        {
        }

        public TransactionRepository(CipContext context) => _context = context;
    }
}

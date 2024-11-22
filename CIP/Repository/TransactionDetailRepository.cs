using CIP.Base;
using CIP.Models;
using Microsoft.EntityFrameworkCore;

namespace CIP.Repository
{
    public class TransactionDetailRepository : GenericRepository<TransactionDetail>
    {
        public TransactionDetailRepository()
        {
        }

        public TransactionDetailRepository(CipContext context) => _context = context;
    }
    
}

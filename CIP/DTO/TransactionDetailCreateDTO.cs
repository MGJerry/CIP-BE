namespace CIP.DTO
{
    public class TransactionDetailCreateDTO
    {
        public int? TransactionId { get; set; }

        public int? ProductId { get; set; }

        public double? Amount { get; set; }

        public double? Subtotal { get; set; }
    }
}

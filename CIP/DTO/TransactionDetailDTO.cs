namespace CIP.DTO
{
    public class TransactionDetailDTO
    {
        public int Id { get; set; }

        public int? TransactionId { get; set; }

        public int? ProductId { get; set; }

        public double? Amount { get; set; }

        public double? Subtotal { get; set; }

    }
}

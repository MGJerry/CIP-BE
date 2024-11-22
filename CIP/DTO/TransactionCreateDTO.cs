namespace CIP.DTO
{
    public class TransactionCreateDTO
    {
        public int? CustomerId { get; set; }

        public string? Type { get; set; }

        public string? Method { get; set; }

        public double? Total { get; set; }

    }
}

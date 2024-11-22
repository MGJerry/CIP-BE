namespace CIP.DTO
{
    public class TransactionRequestDTO
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        public string? Method { get; set; }

        public double? Total { get; set; }
    }
}

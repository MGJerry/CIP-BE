namespace CIP.DTO
{
    public class CustomerCreateDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public int? Gender { get; set; }

        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}

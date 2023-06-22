namespace AddressBook
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Room { get; set; }
        public string? MainWorkplace { get; set; }
        public string? Workplace { get; set; }
    }
}
namespace Project2PHE.DTOs.Vendors
{
    public class RegisterDTO
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
    }
}

namespace BarnCase.Entities
{
    public class HashInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Iterations { get; set; }
    }
}

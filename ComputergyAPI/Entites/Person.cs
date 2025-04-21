namespace ComputergyAPI.Entites
{
    public class Person : MainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool IsLogedIn { get; set; } = false;
    }
}

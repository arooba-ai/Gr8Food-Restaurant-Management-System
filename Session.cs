namespace Gr8Food
{
    public class UserSession
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UserSession(int userId, string name, string email, string role)
        {
            UserID = userId;
            Name = name;
            Email = email;
            Role = role;
        }
    }
}

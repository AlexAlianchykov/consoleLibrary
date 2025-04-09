
namespace LibraryManagementSystem
{
    public class User
    {
        public string Name { get; }
        public int Password { get; }

        private User(string userName, int password)
        {
            Name = userName;
            Password = password;
        }

        public static User Create(string userName, int password)
        {
            User user = new User(userName, password);
            return user;
        }
    }
}


namespace LibraryManagementSystem
{
    public class Login
    {
        private List<User> Users { get; set; } = new List<User>(); // бд юзеров

        public User LoginUser()
        {
            //Console.WriteLine("Войти/зарегистрироваться: ");
            Console.WriteLine("Введите ваше имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль");
            int password = 0;

            for (int i = 0; i < 1; ++i)
            {
                if (int.TryParse(Console.ReadLine(), out password)) { }
                else
                {
                    Console.WriteLine("Пароль должен состоять только из цифр. \n Попробуйте ещё раз:");
                    --i;
                }
            }

            foreach (var user in Users)
            {
                if (user.Name == name && user.Password == password)
                {
                    Console.WriteLine($"Вход выполнен. С возвращением {name}\n");
                    return user;
                }
            }

            var newUser = User.Create(name, password);
            Users.Add(newUser);
            Console.WriteLine("Регистрация прошла успешно. Добро пожаловать!\n");
            return newUser;
        }

    }
}

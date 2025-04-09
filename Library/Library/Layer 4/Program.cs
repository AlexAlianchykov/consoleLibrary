namespace LibraryManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Login db = new Login();
            Library library = new Library();

            for (int cycle = 0; cycle < 1; ++cycle) // цикл удерживающий пользователя в библиотеке
            {
                Console.WriteLine("Добро пожаловать в библиотеку!");

                Console.WriteLine("\n Выбирите действие: \n\n" +
                    "1. Войти в аккаунт или зарегистрироваться. \n" +
                    "2. Выйти из библиотеки.");

                int number1 = 0;
                for (int o = 0; o < 1; ++o)
                {
                    if (int.TryParse(Console.ReadLine(), out number1) && number1 > 0 && number1 < 3) { }
                    else
                    {
                        Console.WriteLine("Введите только цифру от 1 до 2. \n Попробуйте ещё раз:");
                        --o;
                    }
                }

                if(number1 == 2)
                {
                    Console.WriteLine("До новых встреч))");
                    Environment.Exit(0);
                }

                User user = db.LoginUser();
                LibraryСard libraryСard = library.CreateLibraryСard(user);

                Console.WriteLine(
                    "\n1. Пожертвовать книгу в библиотеку \n" +
                    "2. Посмотреть список доступных книг \n" +
                    "3. Взять книгу из библиотеки \n" +
                    "4. Вернуть книгу в библиотеку \n" +
                    "5. Посмотреть список взятых книг \n" +
                    "6. Выйти из аккаунта ");

                for (int i = 0; i < 1; ++i) // цикл удерживающий пользователя в аккаунте
                {
                    Console.WriteLine("\nВыбирите действие: \n");

                    int number2 = 0;
                    for (int j = 0; j < 1; ++j)
                    {
                        if (int.TryParse(Console.ReadLine(), out number2) && number2 > 0 && number2 < 7) { }
                        else
                        {
                            Console.WriteLine("Введите только цифру от 1 до 6. \n Попробуйте ещё раз:");
                            --j;
                        }
                    }
                    var availabilityTrue = library.AvailabilityBookList();

                    switch (number2)
                    {
                        case 1:
                            library.CreateBook();
                            --i;
                            break;
                        case 2:
                            if (availabilityTrue.Count == 0)
                            {
                                Console.WriteLine("Доступных книг в библиотеке нет");
                            }
                            foreach (var bookTrue in availabilityTrue)
                            {
                                Console.WriteLine(bookTrue.ToString());
                            }
                            --i;
                            break;
                        case 3:
                            libraryСard.TakeBook(availabilityTrue);
                            --i;
                            break;
                        case 4:
                            libraryСard.ReutrnBook(library.BookList());
                            --i;
                            break;
                        case 5:
                            if (libraryСard.Books.Count == 0)
                            {
                                Console.WriteLine("Вы ещё не брали книги");
                            }
                            foreach (var book in libraryСard.Books)
                            {
                                Console.WriteLine(book.ToString());
                            }
                            --i;
                            break;
                        case 6:
                            --cycle;
                            break;
                    }

                }
            }

            




        }
    }

}

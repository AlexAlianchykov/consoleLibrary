using LibraryManagementSystem;
using System.Reflection.PortableExecutable;

namespace LibraryManagementSystem
{
    class BookTakenEx : Exception
    {
        public BookTakenEx(string massage) : base(massage) { }
    }

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

    class User // юзер
    {
        public string Name { get; }
        public int Password { get; }

        private User( string userName, int password)
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
    class Book // книга
    {
        public string Title { get; }
        public string Author { get; }
        public bool Availability { get; set; }

        private Book(string title, string author)
        {
            Title = title;
            Author = author;
            Availability = true;
            
        }

        public static Book Create(string title, string author) // создаём новую книгу
        {
            Book book = new Book(title, author);
            return book;
        }


        public override string ToString()
        {
            return $" {Author}, {Title}";
        }

    }

    class LibraryСard  // библиотечная карточка
    {
        public int Number { get; }
        public User User { get; }
        public List<ReadBook> Books { get; } // список книг которые брал/взял юзер 

        private LibraryСard( User user, int number)
        {
            Number = number;
            User = user;
            Books = new List<ReadBook>();
        }

        public static LibraryСard Create(User user, int number) // создание карточки для юзера
        {
            LibraryСard newCard = new LibraryСard(user, number);
            return newCard;
        }

        public void TakeBook(List<Book> books)  // юзер взял книгу
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Доступных книг нет");
                return;
            }

            Console.WriteLine("Введите название книги\n");
            string takeBook = Console.ReadLine();
            foreach (var book in books)
            {
                if(book.Title == takeBook)
                {
                    Books.Add(ReadBook.CreateReadBook(book));
                    book.Availability = false;
                    Console.WriteLine($"\nВы взяли {takeBook}");
                    return;
                }
            }
            Console.WriteLine("К сожалению либо такой книги не существует в библиотеке, либо её уже читают");
        }

        public void ReutrnBook(List<Book> books) // юзер вернул книгу
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("Вы ещё не брали книги");
                return;
            }

            Console.WriteLine("Введите название книги\n");
            string returnBook = Console.ReadLine();

            foreach (var boo in Books)
            {
                if (boo.Book.Title == returnBook)
                {
                    boo.FinishTime = DateTime.Now;
                    Console.WriteLine("Книга возвращенна");
                    boo.Book.Availability = true;
                    return;
                }
            }
            Console.WriteLine("Такую книгу вы не брали");

        }

        
    }

    class ReadBook // чтение книги 
    {
        public Book Book { get; }
        public DateTime StartTime { get; }
        public DateTime? FinishTime { get; set; } = null;

        private ReadBook(Book book, DateTime start)
        {
            Book = book;
            StartTime = start;
        }

        public static ReadBook CreateReadBook(Book book)
        {
            ReadBook readBook = new ReadBook(book, DateTime.Now);
            return readBook;
        }

        public override string ToString()
        {
            if (FinishTime == null)
            {
                return $"{Book.Title} с {StartTime} по нынешнее время";
            }
            return $"{Book.Title} с {StartTime} по {FinishTime}";
        }

    }

    class Library // библиотека
    {
        private List<LibraryСard> СardUsers { get; set; } = new List<LibraryСard>();
        private List<Book> Books { get; set; } = new List<Book>();

        public void CreateBook()  // передача книги в библиотеку
        {
            Console.WriteLine("Введите название книги :");
            string title = Console.ReadLine();
            Console.WriteLine("Введите автора книги :");
            string author = Console.ReadLine();

            var book = Book.Create(title, author);
            Books.Add(book);
            Console.WriteLine("книга в библиотеке");
        }

        public LibraryСard CreateLibraryСard(User user) // создание карточки читателя 
        {
            foreach (var card in СardUsers)
            {
                if (card.User == user)
                {
                    return card;
                }
            }
            int number = СardUsers.Count;
            var newCard = LibraryСard.Create(user, number);
            СardUsers.Add(newCard);
            return newCard;
        }

        public List<Book> AvailabilityBookList() // доступные книги
        {
            List<Book> AvailabilityTrue = new List<Book>();
            foreach (var book in Books)
            {
                if (book.Availability == true)
                {
                    AvailabilityTrue.Add(book);
                }
            }
            return AvailabilityTrue;
        }

        public List<Book> BookList()
        {
            return Books;
        }

        
    }

    class Login // Войти/зарегистрироваться
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

namespace LibraryManagementSystem
{
    public class Library
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
}


namespace LibraryManagementSystem
{
    public class LibraryСard
    {
        public int Number { get; }
        public User User { get; }
        public List<ReadBook> Books { get; } // список книг которые брал/взял юзер 

        private LibraryСard(User user, int number)
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
                if (book.Title == takeBook)
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
}

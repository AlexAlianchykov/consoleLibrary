
namespace LibraryManagementSystem
{
    public class ReadBook
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
}

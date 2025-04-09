namespace LibraryManagementSystem
{
    public class Book
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
}

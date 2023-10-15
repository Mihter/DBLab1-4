namespace DBLab1
{
    class Program
    {
        static void Main()
        {
            //ФИО и уникальный номер читательского билета
            Student student = new Student
            {
                FullName = "Петя Петров Петрович",
                Ticket = 1,
            };
            var book = new Book
            {
                Id = 1,
                Author = "Фёдор михайлович Достоевский",
                Name = "Преступление и наказание",
                ReleaseDate = new DateOnly(1865, 10, 5),
                IdBookShelf = 1,
                IdShelf = 1,
            };
            var bookStat = new BookStat
            {
                Id = 1,
                StudentId = student,
                BookId = book,
                TakeDate = new DateOnly(2022, 07, 07),
                ReturnDate = new DateOnly(2022, 12, 12),
            };
        }
    }
}
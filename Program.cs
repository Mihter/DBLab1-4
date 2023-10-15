

namespace DBLab1
{
    class Program
    {
        static void Main()
        {
            try
            {
                List<Student> students = TableParser.ParseStudents(@"..\..\..\Date\Student.csv");
                List<Book> books = TableParser.ParseBooks(@"..\..\..\Date\Book.csv");
                List<BookStat> bookStats = TableParser.ParseBookStats(@"..\..\..\Date\BookStatistics.csv", students, books);

                ////вывод всех книг и кто какие брал
                TableDisplay.ViewTable(students, books, bookStats);
            }
            catch (ArgumentException ex) 
            {
                Console.Clear();
                Console.WriteLine("Ошибка:"+ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DBLab1
{
    internal class TableDisplay
    {
        public static void ViewTable(List<Student> students, List<Book> books, List<BookStat> bookStats)
        {
            int maxLenNameBook = FindMaxLenNameBook(books);
            int maxLenAuthor = FindMaxLenAuthor(books);
            int maxLenFullNameStudent = FindMaxLenFullNameStudent(students, books, bookStats);

            ReturnHeading(maxLenAuthor, maxLenNameBook, maxLenFullNameStudent);
            ReturnTable(books, bookStats, maxLenAuthor, maxLenNameBook, maxLenFullNameStudent);
        }

        private static int FindMaxLenNameBook(List<Book> books)
        {
            int maxLenNameBook = 0;
            foreach (Book book in books)
            {
                maxLenNameBook = Math.Max(maxLenNameBook, book.Name.Length);
            }
            return maxLenNameBook;
        }

        private static int FindMaxLenAuthor(List<Book> books)
        {
            int maxLenAuthor = 0;
            foreach (Book book in books)
            {
                maxLenAuthor = Math.Max(maxLenAuthor, book.Author.Length);
            }
            return maxLenAuthor;
        }

        private static int FindMaxLenFullNameStudent(List<Student> students, List<Book> books, List<BookStat> bookStats)
        {
            int maxLenNameReader = 0;

            foreach (Book book in books)
            {
                foreach (BookStat stat in bookStats)
                {
                    if (stat.Book.Id == book.Id)
                    {
                        maxLenNameReader = Math.Max(maxLenNameReader, stat.Student.FullName.Length);
                    }
                }
            }

            return maxLenNameReader;
        }

        private static void ReturnHeading(int maxLenAuthor, int maxLenNameBook, int maxLenFullNameStudent)
        {
            Console.Write("| ");
            Console.Write("Автор".PadRight(maxLenAuthor));
            Console.Write(" | ");

            Console.Write("Название".PadRight(maxLenNameBook));
            Console.Write(" | ");

            Console.Write("Читает".PadRight(maxLenFullNameStudent));
            Console.Write(" | ");

            Console.Write("Взял".PadRight(10));
            Console.WriteLine(" |");

            Console.Write("| ");
            Console.Write(new string('-', maxLenAuthor));
            Console.Write(" | ");

            Console.Write(new string('-', maxLenNameBook));
            Console.Write(" | ");

            Console.Write(new string('-', maxLenFullNameStudent));
            Console.Write(" | ");

            Console.Write("".PadRight(10, '-'));
            Console.WriteLine(" |");
        }

        private static void ReturnTable(List<Book> books, List<BookStat> bookStats, int maxLenAuthor, int maxLenNameBook, int maxLenFullNameStudent)
        {
            foreach (Book book in books)
            {
                Console.Write("| ");
                Console.Write(book.Author.PadRight(maxLenAuthor));
                Console.Write(" | ");

                Console.Write(book.Name.PadRight(maxLenNameBook));
                Console.Write(" | ");

                // проверяем - взял ли кто-то эту книгу и если да, записываем его имя и когда он ёё взял
                string studentFullName = "";
                DateOnly? takeDate = DateOnly.MinValue;
                foreach (BookStat stat in bookStats)
                {
                    if (stat.Book.Id == book.Id)
                    {
                        studentFullName = stat.Student.FullName;
                        takeDate = stat.TakeDate;
                        break;
                    }
                }

                Console.Write(studentFullName.PadRight(maxLenFullNameStudent));
                Console.Write(" | ");

                if (takeDate != DateOnly.MinValue)
                {
                    Console.Write(takeDate);
                }
                else
                {
                    Console.Write(new string(' ', 10));
                }

                Console.WriteLine(" |");
            }
        }
    }
}

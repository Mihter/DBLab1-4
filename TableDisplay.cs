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
            Console.WriteLine("|Автор | Название | Читает | Взял |\r\n|----|------|----|--------|\r");
            foreach (Book book in books)
            {
                Console.Write("| " + book.Name + " | ");
                foreach (BookStat stat in bookStats)
                {
                    if (book.Id == stat.BookId)
                    {
                        foreach (Student student in students)
                        {
                            if (student.Ticket == stat.StudentId)
                            {
                                Console.Write(student.FullName + " | " + stat.TakeDate.ToString() + " |");
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

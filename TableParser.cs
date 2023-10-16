

using System.Reflection.PortableExecutable;

//namespace DBLab1
//{
//    static class TableParser
//    {
//        //Проверяем студентов
//        public static string[] ParseFile(string path)
//        {
//            string[] allLinesRawRows = File.ReadAllLines(path);

//            for (int i = 0; i < allLinesRawRows.Length; i++)
//            {
//                string[] elementsOfLine = allLinesRawRows[i].Split(";");

//                if (elementsOfLine.Length > 2)
//                {
//                    throw new ArgumentException($"В файле Student.csv {i + 1} строка имеет столбцов больше чем 2");
//                }
//                if (!uint.TryParse(elementsOfLine[0], out uint id))
//                {
//                    throw new ArgumentException($"В файле Student.csv в {i + 1} строке в 1 столбце записаны некорректные данные");
//                }
//                students.Add(new RawRows { Ticket = id, FullName = elementsOfLine[1] });
//            }
//            return students;
//        }
    
//        //проверяем Книги
//        public static List<Table> ParseBooks(string path)
//        {
//            List<Table> books = new List<Table>();
//            string[] allLinesBook = File.ReadAllLines(path);

//            for (int i = 0; i < allLinesBook.Length; i++)
//            {
//                string[] elementsOfLine = allLinesBook[i].Split(";");

//                uint id, idBookShelf, idShelf;
//                DateOnly releaseDate;
//                ReadBooksLine(i, elementsOfLine, out id, out releaseDate, out idBookShelf, out idShelf);

//                books.Add(new Table
//                {
//                    Id = id,
//                    Author = elementsOfLine[1],
//                    Name = elementsOfLine[2],
//                    ReleaseDate = releaseDate,
//                    IdBookShelf = idBookShelf,
//                    IdShelf = idShelf
//                });
//            }
//            return books;
//        }

//        private static void ReadBooksLine(int i, string[] elementsOfLine, out uint id, out DateOnly releaseDate, out uint bookShelfId, out uint shelfId)
//        {
//            СheckBooksLineLength(i, elementsOfLine);

//            id = ParseBookId(i, elementsOfLine);
//            releaseDate = ParseBookReleaseDate(i, elementsOfLine);
//            bookShelfId = ParseBookBookShelfId(i, elementsOfLine);
//            shelfId = ParseBookShelfId(i, elementsOfLine);
//        }

//        private static void СheckBooksLineLength(int i, string[] elementsOfLine)
//        {
//            if (elementsOfLine.Length > 6)
//            {
//                throw new ArgumentException($"В файле Book.csv в {i + 1} строке столбцов больше чем 6");
//            }
//        }

//        private static uint ParseBookId(int i, string[] elementsOfLine)
//        {
//            uint id;
//            if (!uint.TryParse(elementsOfLine[0], out id))
//            {
//                throw new ArgumentException($"В файле Book.csv в {i + 1} строке в столбце 1 записаны некорректные данные");
//            }

//            return id;
//        }

//        private static DateOnly ParseBookReleaseDate(int i, string[] elementsOfLine)
//        {
//            DateOnly releaseDate;
//            if (!DateOnly.TryParse(elementsOfLine[3], out releaseDate))
//            {
//                throw new ArgumentException($"В файле Book.csv в {i + 1} строке в столбце 4 записаны некорректные данные");
//            }

//            return releaseDate;
//        }

//        private static uint ParseBookBookShelfId(int i, string[] elementsOfLine)
//        {
//            uint idBookShelf;
//            if (!uint.TryParse(elementsOfLine[4], out idBookShelf))
//            {
//                throw new ArgumentException($"В файле Book.csv в {i + 1} строке в столбце 5 записаны некорректные данные");
//            }

//            return idBookShelf;
//        }

//        private static uint ParseBookShelfId(int i, string[] elementsOfLine)
//        {
//            uint shelfId;
//            if (!uint.TryParse(elementsOfLine[5], out shelfId))
//            {
//                throw new ArgumentException($"В файле Book.csv в {i + 1} строке в столбце 6 записаны некорректные данные");
//            }

//            return shelfId;
//        }

//        //парсим статистику по книге
//        public static List<BookStat> ParseBookStats(string path, List<Student> students, List<Table> books)
//        {
//            List<BookStat> stats = new List<BookStat>();
//            string[] allLinesStats = File.ReadAllLines(path);
        
//            for (int i = 0; i < allLinesStats.Length; i++)
//            {
//                string[] elementsOfLine = allLinesStats[i].Split(";");

//                uint id, studentId, bookId;
//                DateOnly takeDate, returnDate;
//                ReadBookStatsLine(i, elementsOfLine, out id, out studentId, out bookId, out takeDate, out returnDate);

//                Student studentStats = ParseStatsStudent(students, i, studentId);

//                Table bookStats = ParseStatsBook(books, i, bookId);

//                stats.Add(new BookStat
//                {
//                    Id = id,
//                    Student = studentStats,
//                    Book = bookStats,
//                    TakeDate = takeDate,
//                    ReturnDate = returnDate,
//                });
//            }
//            return stats;
//        }

//        private static Student ParseStatsStudent(List<Student> students, int i, uint studentId)
//        {
//            Student studentStats = null;
//            bool studentFlag = false;
//            foreach (Student student in students)
//            {
//                if (student.Ticket == studentId)
//                {
//                    studentStats = student;
//                    studentFlag = true;
//                    break;
//                }
//            }

//            if (!studentFlag)
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 2 введен ticket несуществующего читателя");
//            }

//            return studentStats;
//        }

//        private static Table ParseStatsBook(List<Table> books, int i, uint bookId)
//        {
//            Table bookStats = null;
//            bool bookFlag = false;
//            foreach (Table book in books)
//            {
//                if (book.Id == bookId)
//                {
//                    bookStats = book;
//                    bookFlag = true;
//                    break;
//                }
//            }

//            if (!bookFlag)
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 3 введено id несуществующей книги");
//            }

//            return bookStats;
//        }

//        public static void ReadBookStatsLine(int i, string[] elementsOfLine, out uint id, out uint studentId, out uint bookId, out DateOnly takeDate, out DateOnly returnDate)
//        {
//            CheckBookStatsLineLength(i, elementsOfLine);

//            id = BookStatsLineId(i, elementsOfLine);
//            studentId = BookStatsLineStudentId(i, elementsOfLine);
//            bookId = BookStatsLineBookId(i, elementsOfLine);
//            takeDate = BookStatsLineTakeDate(i, elementsOfLine);
//            returnDate = BookStatsLineReturnDate(i, elementsOfLine);
//        }

//        private static void CheckBookStatsLineLength(int i, string[] elementsOfLine)
//        {
//            if (elementsOfLine.Length > 5)
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке столбцов больше чем 5");
//            }
//        }
//        private static uint BookStatsLineId(int i, string[] elementsOfLine)
//        {
//            if (!uint.TryParse(elementsOfLine[0], out uint id))
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 1 записаны некорректные данные");
//            }

//            return id;
//        }

//        private static uint BookStatsLineStudentId(int i, string[] elementsOfLine)
//        {
//            if (!uint.TryParse(elementsOfLine[1], out uint studentId))
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 2 записаны некорректные данные");
//            }

//            return studentId;
//        }
//        private static uint BookStatsLineBookId(int i, string[] elementsOfLine)
//        {
//            if (!uint.TryParse(elementsOfLine[2], out uint bookId))
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 3 записаны некорректные данные");
//            }

//            return bookId;
//        }

//        private static DateOnly BookStatsLineTakeDate(int i, string[] elementsOfLine)
//        {
//            if (!DateOnly.TryParse(elementsOfLine[3], out DateOnly takeDate))
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 4 записаны некорректные данные");
//            }

//            return takeDate;
//        }

//        private static DateOnly BookStatsLineReturnDate(int i, string[] elementsOfLine)
//        {
//            if (!DateOnly.TryParse(elementsOfLine[3], out DateOnly returnDate))
//            {
//                throw new ArgumentException($"В файле BookStatistics.csv в {i + 1} строке в столбце 5 записаны некорректные данные");
//            }

//            return returnDate;
//        }
//    }
//}

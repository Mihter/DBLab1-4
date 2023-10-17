

using System.IO;
using System.Text.Json;

namespace DBLab1
{
    class Program
    {
        public static async Task Main()
        {
           
            //string jsonString = JsonSerializer.DeserializeAsync<TableScheme>(rawRows);
            try
            {
                string fileName = @"..\..\..\Scheme\Book.json";
                using FileStream openStream = File.OpenRead(fileName);
                TableScheme? tableScheme =
                    await JsonSerializer.DeserializeAsync<TableScheme>(openStream);
                var anyTableScheme = new TableScheme();
                string[] rawRows = anyTableScheme.Validate(@"..\..\..\Date\Book.csv");
                //List<Table> books = TableParser.ParseBooks(@"..\..\..\Date\Book.csv");
                //List<BookStat> bookStats = TableParser.ParseBookStats(@"..\..\..\Date\BookStatistics.csv", students, books);

                ////вывод всех книг и кто какие брал
                //TableDisplay.ViewTable(students, books, bookStats);
            }
            catch (ArgumentException ex) 
            {
                Console.Clear();
                Console.WriteLine("Ошибка:"+ex.Message);
            }
        }
    }
}
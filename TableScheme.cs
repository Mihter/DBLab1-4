using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DBLab1
{
    // тут используется термин "схема", чтобы подчеркнуть,  что это не сама таблица. т.е. табличные данные, а описание структуры таблицы
    public class TableScheme
    {
        public string Name { get; }

        // в таблице есть список столбцов
        public List<Column> Columns { get; }

        
        public string[] Validate(string path)
        {
            string[] rawRows = File.ReadAllLines(path);

            for (int i = 0; i < rawRows.Length; i++)
            {
                //string[] elementsOfLine = rawRows[i].Split(";");

                if (rawRows[i].Length == 4)
                {
                throw new ArgumentException($"В файле Book.csv в {i + 1} строке в 1 столбце записаны некорректные данные");
            }
            //rawRows.Add(new Student { Ticket = id, FullName = elementsOfLine[1] });
        }
            return rawRows;
        }
        // конструктор, чтобы заполнить объект при создании
        //public Table(...)
        //{
        //    // ...
        //}
    }

    public class Column
    {
        public string Name { get; }

        // у колонки есть тип данных в ней
        public ColumnType DataType { get; }
    }

    public enum ColumnType
    {
        Int, Float, String
    }

}

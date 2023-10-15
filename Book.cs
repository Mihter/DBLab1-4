using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBLab1
{
    public class Book
    {
        public uint? Id { get; set; }
        public string? Author { get; set; }
        public string? Name { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public uint? IdBookShelf { get; set; }
        public uint? IdShelf { get; set; }

    }
}

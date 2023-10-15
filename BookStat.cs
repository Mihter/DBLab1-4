using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DBLab1
{
    public class BookStat
    {
        public uint? Id { get; set; }
        public uint? StudentId { get; set; }
        public uint? BookId { get; set; }
        public DateOnly? TakeDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Searching;

namespace Main
{
    public class Sparepart : ISparepart
    {
        public string Nama { get; set; }
        public string Kategori { get; set; }
        public string Merek { get; set; }
        public string KompatibelDengan { get; set; }
        public decimal Harga { get; set; }
    }
}

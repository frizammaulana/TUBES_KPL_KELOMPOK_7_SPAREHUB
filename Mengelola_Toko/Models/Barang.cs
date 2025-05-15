using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mengelola_Toko.Models
{
    public class Barang
    {
        public string Id { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public int Stok { get; set; }
    }
}

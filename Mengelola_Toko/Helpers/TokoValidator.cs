using Mengelola_Toko.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mengelola_Toko.Helpers
{
    class TokoValidator
    {
        public static void ValidasiBarang(Barang barang)
        {
           

            
            Debug.Assert(!string.IsNullOrWhiteSpace(barang.Nama), "Nama barang tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(barang.Nama))
                throw new ArgumentException("Nama barang tidak boleh kosong.");

            Debug.Assert(!string.IsNullOrWhiteSpace(barang.Deskripsi), "Deskripsi barang tidak boleh kosong.");
            if (string.IsNullOrWhiteSpace(barang.Deskripsi))
                throw new ArgumentException("Deskripsi barang tidak boleh kosong.");

            Debug.Assert(barang.Stok >= 0, "Stok tidak boleh negatif.");
            if (barang.Stok < 0)
                throw new ArgumentException("Stok tidak boleh negatif.");

            Debug.Assert(barang.Harga >= 0, "Harga tidak boleh negatif.");
            if (barang.Harga < 0)
                throw new ArgumentException("Harga tidak boleh negatif.");

        }
    }
}

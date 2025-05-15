using Mengelola_Toko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mengelola_Toko.Models;

namespace Mengelola_Toko.Helpers
{
    class TokoValidator
    {
        public static void ValidasiBarang(Barang barang)
        {
            // Code Reuse : ValidasiNama bisa dipake di mana-mana, reusable
            // DbC : Cek precondition, kalau nama kosong → throw exception
            if (string.IsNullOrWhiteSpace(barang.Nama))
                throw new ArgumentException("Nama barang tidak boleh kosong.");

            // Code Reuse : ValidasiDeskripsi bisa dipake di mana-mana, reusable
            // DbC : Cek precondition, kalau Deskripsi kosong → throw exception
            if (string.IsNullOrWhiteSpace(barang.Deskripsi))
                throw new ArgumentException("Deskripsi barang tidak boleh kosong.");

            // Code Reuse : ValidasiStok reusable buat pastikan stok valid
            // DbC : Cek precondition, stok minimal 0
            if (barang.Stok < 0)
                throw new ArgumentException("Stok tidak boleh negatif.");
        }
    }
}

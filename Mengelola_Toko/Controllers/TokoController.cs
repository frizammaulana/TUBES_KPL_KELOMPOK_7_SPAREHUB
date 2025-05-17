using Mengelola_Toko.Models;
using Mengelola_Toko.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mengelola_Toko.Models;
using Mengelola_Toko.Services;

namespace Mengelola_Toko.Controllers
{
    class TokoController
    {
        private readonly TokoServices service = new();  // <- service dipanggil, kayak akses API endpoint di backend

        // API : TambahBarang acting sebagai POST /barang
        public void TambahBarang(string nama, string deskripsi, int stok, int harga)
        {
            // Code Reuse: class Barang dipake berkali-kali buat bikin objek
            var barang = new Barang
            {
                Nama = nama,
                Deskripsi = deskripsi,
                Stok = stok,
                Harga = harga
            };

            // API : panggil 'endpoint' TambahBarang di Service
            service.TambahBarang(barang);

            Console.WriteLine("Barang berhasil ditambah.");
        }

        // API : GET /barang
        public void TampilkanBarang()
        {
            var semua = service.GetSemuaBarang();

            if (semua.Count == 0)
            {
                Console.WriteLine("Belum ada barang.");
                return;
            }

            foreach (var b in semua)
                Console.WriteLine($"ID: {b.Id} | {b.Nama} - {b.Deskripsi} | Rp.{b.Harga}.00");
        }

        // API : PUT /barang/{id}
        public void UbahDeskripsiBarang(string id, string deskripsiBaru)
        {
            service.UbahDeskripsi(id, deskripsiBaru);
            Console.WriteLine("Deskripsi barang berhasil diubah.");
        }

        // API : DELETE /barang/{id}
        public void HapusBarang(string id)
        {
            service.HapusBarang(id);
            Console.WriteLine("Barang berhasil dihapus.");
        }

        // API : GET /barang/{id}/stok
        public int LihatStokBarang(string id)
        {
            return service.LihatStok(id);
        }
    }
}

using Mengelola_Toko.Helpers;
using Mengelola_Toko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mengelola_Toko.Helpers;
using Mengelola_Toko.Models;

namespace Mengelola_Toko.Services
{
    public class TokoServices
    {
        private List<Barang> daftarBarang = new();
        private int idCounter = 1;

        // API — Representasi endpoint: POST /barang
        // Code reuse/library — Pakai Valdisa untuk validasi
        public void TambahBarang(Barang barang)
        {
            TokoValidator.ValidasiBarang(barang); // Reuse validator untuk cek input
            barang.Id = idCounter.ToString();    
            idCounter++;
            daftarBarang.Add(barang);            
        }

        // API — Representasi endpoint: GET /barang
        public List<Barang> GetSemuaBarang() => daftarBarang;

        // API — Representasi endpoint: PUT /barang/{id}
        public void UbahDeskripsi(string id, string deskripsiBaru)
        {
            var barang = daftarBarang.FirstOrDefault(b => b.Id == id);
            if (barang == null)
                throw new Exception("Barang tidak ditemukan.");

            if (string.IsNullOrWhiteSpace(deskripsiBaru))
                throw new ArgumentException("Deskripsi tidak boleh kosong."); 

            barang.Deskripsi = deskripsiBaru;
        }

        // API — Representasi endpoint: DELETE /barang/{id}
        public void HapusBarang(string id)
        {
            var barang = daftarBarang.FirstOrDefault(b => b.Id == id);
            if (barang == null)
                throw new Exception("Barang tidak ditemukan."); 

            daftarBarang.Remove(barang);
        }

        // API — Representasi endpoint: GET /barang/{id}/stok
        public int LihatStok(string id)
        {
            var barang = daftarBarang.FirstOrDefault(b => b.Id == id);
            if (barang == null)
                throw new Exception("Barang tidak ditemukan.");

            return barang.Stok;
        }
    }

}


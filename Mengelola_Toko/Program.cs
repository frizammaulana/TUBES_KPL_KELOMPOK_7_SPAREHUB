using Mengelola_Toko.Models;
using Mengelola_Toko.Services;
using Mengelola_Toko.Controllers;
using System.Diagnostics;
using Mengelola_Toko.Helpers;


var controller = new TokoController();

while (true)
{
    Console.WriteLine("\n=== MENU MANAJEMEN BARANG ===");
    Console.WriteLine("1. Tambah Barang");
    Console.WriteLine("2. Lihat Semua Barang");
    Console.WriteLine("3. Ubah Deskripsi Barang");
    Console.WriteLine("4. Hapus Barang");
    Console.WriteLine("5. Lihat Stok Barang");  // ⬅️ Tambahan menu stok
    Console.WriteLine("0. Keluar");
    Console.Write("Pilih menu: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            try
            {
                Console.Write("Nama Barang: ");
                string nama = Console.ReadLine();
                Console.Write("Deskripsi Barang: ");
                string deskripsi = Console.ReadLine();
                Console.Write("Stok Barang: ");
                if (!int.TryParse(Console.ReadLine(), out int stok))
                {
                    Console.WriteLine("❌ ERROR: Stok harus berupa angka.");
                    break;
                }

                var barang = new Barang
                {
                    Nama = nama,
                    Deskripsi = deskripsi,
                    Stok = stok
                };

                TokoValidator.ValidasiBarang(barang);  // Validasi disini, kalau gagal langsung throw

                controller.TambahBarang(nama, deskripsi, stok);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
            }
            break;

        case "2":
            controller.TampilkanBarang();
            break;

        case "3":
            Console.Write("ID Barang: ");
            string id = Console.ReadLine();
            Console.Write("Deskripsi Baru: ");
            string deskripsiBaru = Console.ReadLine();
            try
            {
                controller.UbahDeskripsiBarang(id, deskripsiBaru);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
            }
            break;

        case "4":
            Console.Write("ID Barang: ");
            string idHapus = Console.ReadLine();
            try
            {
                controller.HapusBarang(idHapus);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
            }
            break;

        case "5":   // ⬅️ menu liat stok
            Console.Write("ID Barang: ");
            string idStok = Console.ReadLine();
            try
            {
                int stokBarang = controller.LihatStokBarang(idStok);
                Console.WriteLine($"Stok Barang ID {idStok}: {stokBarang}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ ERROR: {ex.Message}");
            }
            break;

        case "0":
            Console.WriteLine("Keluar...");
            return;

        default:
            Console.WriteLine("Pilihan tidak valid.");
            break;
    }
}
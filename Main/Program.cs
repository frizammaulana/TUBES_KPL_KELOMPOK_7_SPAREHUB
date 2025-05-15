using System;
using System.Collections.Generic;
using Searching;
using Main;

public class Program
{
    static void Main()
    {
        var data = Utility.AmbilDataDummy();
        var mesin = new SearchEngine<Sparepart>(data);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistem Pencarian Sparepart ===");
            Console.WriteLine("1. Cari berdasarkan Kategori");
            Console.WriteLine("2. Cari berdasarkan Merek");
            Console.WriteLine("3. Cari berdasarkan Kompatibilitas");
            Console.WriteLine("0. Keluar");
            Console.Write("Pilihan Anda: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "0")
            {
                Console.WriteLine("Terima kasih!");
                break;
            }

            Console.Write("Masukkan kata kunci pencarian: ");
            string keyword = Console.ReadLine();

            List<Sparepart> hasil = null;

            try
            {
                switch (pilihan)
                {
                    case "1":
                        hasil = mesin.CariBerdasarkanKategori(keyword);
                        break;
                    case "2":
                        hasil = mesin.CariBerdasarkanMerek(keyword);
                        break;
                    case "3":
                        hasil = mesin.CariBerdasarkanKompatibilitas(keyword);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }

                if (hasil != null && hasil.Count > 0)
                {
                    Console.WriteLine("\nHasil Pencarian:\n");
                    Console.WriteLine("{0,-25} | {1,-15} | {2,-15} | {3,-20} | {4,10}", "Nama", "Kategori", "Merek", "Kompatibel Dengan", "Harga");
                    Console.WriteLine(new string('-', 95));
                    foreach (var item in hasil)
                    {
                        Console.WriteLine("{0,-25} | {1,-15} | {2,-15} | {3,-20} | Rp{4,8:N0}",
                            item.Nama,
                            item.Kategori,
                            item.Merek,
                            item.KompatibelDengan,
                            item.Harga);
                    }
                }

                else
                {
                    Console.WriteLine("Tidak ada hasil yang ditemukan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }

            Console.WriteLine("\nTekan ENTER untuk melanjutkan...");
            Console.ReadLine();
        }
    }
}

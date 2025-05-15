using System;
using System.Collections.Generic;

namespace UlasanDanRatingProduk
{
    internal class Program
    {
        static ReviewService reviewService = new ReviewService();
        static Dictionary<string, Product> produkList = new();

        static void Main(string[] args)
        {
            SeedData();

            int pilihan;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Ulasan & Rating Produk");
                Console.WriteLine("1. Lihat produk");
                Console.WriteLine("2. Tambah review produk");
                Console.WriteLine("3. Lihat review produk");
                Console.WriteLine("0. Keluar");
                Console.Write("Pilih menu: ");

                if (!int.TryParse(Console.ReadLine(), out pilihan))
                {
                    Console.WriteLine("Input tidak valid. Tekan enter untuk lanjut...");
                    Console.ReadLine();
                    continue;
                }

                switch (pilihan)
                {
                    case 1:
                        TampilkanProduk();
                        break;
                    case 2:
                        TambahReview();
                        break;
                    case 3:
                        LihatReview();
                        break;
                    case 0:
                        Console.WriteLine("Terima kasih!");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak tersedia.");
                        break;
                }

                Console.WriteLine("\nTekan enter untuk kembali ke menu...");
                Console.ReadLine();

            } while (pilihan != 0);
        }

        static void SeedData()
        {
            produkList["P001"] = new Product("P001", "Laptop Gaming XYZ");
            produkList["P002"] = new Product("P002", "Smartphone Pro 12");
            produkList["P003"] = new Product("P003", "Kipas Angin Turbo");
        }

        static void TampilkanProduk()
        {
            Console.WriteLine("\nDaftar Produk:");
            foreach (var p in produkList.Values)
            {
                Console.WriteLine($"- {p.Id}: {p.Name}");
            }
        }

        static void TambahReview()
        {
            TampilkanProduk();
            Console.Write("\nMasukkan ID produk: ");
            string id = Console.ReadLine()?.Trim().ToUpper();

            if (!produkList.ContainsKey(id))
            {
                Console.WriteLine("Produk tidak ditemukan.");
                return;
            }

            Console.Write("Nama Anda: ");
            string reviewer = Console.ReadLine()?.Trim();

            Console.Write("Komentar: ");
            string komentar = Console.ReadLine()?.Trim();

            Console.Write("Rating (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out int rating))
            {
                Console.WriteLine("Rating tidak valid.");
                return;
            }

            try
            {
                var review = new Review(reviewer, komentar, rating);
                review.Submit();
                reviewService.AddReview(id, review);
                Console.WriteLine("Review berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal menambahkan review: " + ex.Message);
            }
        }

        static void LihatReview()
        {
            TampilkanProduk();
            Console.Write("\nMasukkan ID produk: ");
            string id = Console.ReadLine()?.Trim().ToUpper();

            if (!produkList.ContainsKey(id))
            {
                Console.WriteLine("Produk tidak ditemukan.");
                return;
            }

            Console.WriteLine($"\nReview untuk produk: {produkList[id].Name}");
            reviewService.ShowReviews(id);
        }
    }
}
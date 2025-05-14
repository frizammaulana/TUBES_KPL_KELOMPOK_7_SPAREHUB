using System;

class Program
{
    public static void Main(string[] args)
    {
        Order orderSystem = new Order();

        while (true)
        {
            Console.WriteLine("\n1. Tambah produk ke keranjang");
            Console.WriteLine("2. Proses pesanan");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih opsi: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    orderSystem.AddToCart();
                    break;
                case "2":
                    orderSystem.ProcessOrder();
                    break;
                case "3":
                    Console.WriteLine("Keluar dari sistem...");
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }
        }
    }

}

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;

public class CartItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
}

public class Order
{
    private string CartFile = "C:\\Users\\Lenovo\\Desktop\\KPL\\fitur_Order\\keranjang.json";
    private const string ConfigFile = "C:\\Users\\Lenovo\\Desktop\\KPL\\fitur_Order\\config.json";
    private const string StatusFile = "C:\\Users\\Lenovo\\Desktop\\KPL\\fitur_Order\\status_mapping.json";

    private Dictionary<string, string> config;
    private Dictionary<string, string> statusMap;

    // Table-driven list of payment methods
    private List<string> validPayments = new List<string> { "COD", "Transfer", "E-Wallet", "Kartu Kredit" };

    public Order(string cartFilePath = null)
    {
        CartFile = cartFilePath ?? "C:\\Users\\Lenovo\\Desktop\\KPL\\fitur_Order\\keranjang.json";
        LoadRuntimeConfig();
        LoadStatusMapping();
    }

    private void LoadRuntimeConfig()
    {
        if (File.Exists(ConfigFile))
        {
            string json = File.ReadAllText(ConfigFile);
            config = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        else
        {
            config = new Dictionary<string, string>
            {
                { "language", "id" },
                { "payment_method", "COD" },
                { "shipping", "J&T" }
            };
        }
    }

    private void LoadStatusMapping()
    {
        if (File.Exists(StatusFile))
        {
            string json = File.ReadAllText(StatusFile);
            statusMap = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        else
        {
            statusMap = new Dictionary<string, string>
            {
                { "1", "Diproses" },
                { "2", "Dikirim" },
                { "3", "Selesai" }
            };
        }
    }

    public List<CartItem> LoadCart()
    {
        if (!File.Exists(CartFile))
        {
            Console.WriteLine("Keranjang kosong.");
            return new List<CartItem>();
        }

        string json = File.ReadAllText(CartFile);
        return JsonSerializer.Deserialize<List<CartItem>>(json);
    }
    public void AddToCart()
    {
        List<CartItem> cart = LoadCart();
        Console.Write("Masukkan nama produk: ");
        string name = Console.ReadLine();

        Console.Write("Masukkan jumlah: ");
        int qty = int.Parse(Console.ReadLine());

        Console.Write("Masukkan harga satuan: ");
        int price = int.Parse(Console.ReadLine());

        Debug.Assert(qty > 0, "Tidak boleh negatif");
        Debug.Assert(price > 0, "Tidak boleh negatif");

        CartItem newItem = new CartItem
        {
            ProductId = Guid.NewGuid().ToString(),
            ProductName = name,
            Quantity = qty,
            Price = price
        };

        cart.Add(newItem);

        string json = JsonSerializer.Serialize(cart, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(CartFile, json);

        Console.WriteLine("Produk berhasil ditambahkan ke keranjang.");

    }

    public void ProcessOrder()
    {
        List<CartItem> cart = LoadCart();

        if (cart.Count == 0)
        {
            Console.WriteLine("Keranjang kosong. Tidak ada pesanan yang dapat diproses.");
            return;
        }

        Console.WriteLine("=== DAFTAR PRODUK DI KERANJANG ===");
        int total = 0;
        foreach (var item in cart)
        {
            Debug.Assert(item.Quantity > 0, "Jumlah produk harus positif.");
            Debug.Assert(item.Price > 0, "Harga produk tidak boleh nol.");

            int subtotal = item.Quantity * item.Price;
            total += subtotal;

            Console.WriteLine($"- {item.ProductName} x{item.Quantity} @ Rp{item.Price:N0} → Rp{subtotal:N0}");
        }

        // Tampilkan metode pembayaran yang tersedia
        Console.WriteLine("\nPilih metode pembayaran:");
        for (int i = 0; i < validPayments.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {validPayments[i]}");
        }

        Console.Write("Masukkan nomor metode pembayaran yang dipilih: ");
        string choiceInput = Console.ReadLine();
        int choice;
        if (!int.TryParse(choiceInput, out choice) || choice < 1 || choice > validPayments.Count)
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        string selectedPayment = validPayments[choice - 1];
        config["payment_method"] = selectedPayment; // update config runtime

        Console.WriteLine($"\nMetode Pembayaran: {selectedPayment}");
        Console.WriteLine($"Pengiriman via: {config["shipping"]}");
        Console.WriteLine($"TOTAL: Rp{total:N0}");

        Console.Write("Lanjutkan pemesanan? (y/n): ");
        string confirm = Console.ReadLine();

        if (confirm.ToLower() == "y")
        {
            Console.WriteLine("\nPesanan sedang diproses...");
            string status = statusMap.ContainsKey("1") ? statusMap["1"] : "Unknown";

            Console.WriteLine($"Status pesanan: {status}");

            File.WriteAllText(CartFile, "[]");
            Console.WriteLine("Keranjang dikosongkan.");
        }
        else
        {
            Console.WriteLine("Pemesanan dibatalkan.");
        }
    }
}

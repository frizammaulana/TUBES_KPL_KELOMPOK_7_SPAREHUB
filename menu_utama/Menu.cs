using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics.Contracts;

public class Menu
{
    private const string ConfigFile = "C:\\Users\\Lenovo\\Desktop\\KPL\\menu_utama\\configMenu.json";
    private Dictionary<string, string> config;
    private Dictionary<string, Dictionary<string, string>> translations;

    public Menu()
    {
        LoadTranslations(); // Load dulu supaya bisa dipakai saat pilih bahasa
        InitOrSelectLanguage();
        SaveConfig(); // simpan bahasa terpilih
    }

    private void InitOrSelectLanguage()
    {
        if (File.Exists(ConfigFile))
        {
            string json = File.ReadAllText(ConfigFile);
            config = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }
        else
        {
            config = new Dictionary<string, string>();
        }

        Console.Clear();
        Console.WriteLine("Pilih bahasa / Select language:");
        Console.WriteLine("1. Indonesia");
        Console.WriteLine("2. English");
        Console.WriteLine("(Pilih angkanya/ Select the number)");
        Console.Write(">> ");
        string langChoice = Console.ReadLine();

        switch (langChoice)
        {
            case "1":
                config["language"] = "id";
                break;
            case "2":
                config["language"] = "en";
                break;
            default:
                Console.WriteLine("Pilihan tidak dikenali. Default: Indonesia");
                config["language"] = "id";
                break;
        }

        // Defensive programming
        if (!translations.ContainsKey(config["language"]))
        {
            Console.WriteLine("Bahasa tidak tersedia. Gunakan default (id).");
            config["language"] = "id";
        }

        Contract.Requires(translations.ContainsKey(config["language"]));
    }

    private void SaveConfig()
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ConfigFile, json);
    }

    private void LoadTranslations()
    {
        translations = new Dictionary<string, Dictionary<string, string>>
        {
            ["id"] = new Dictionary<string, string>
            {
                ["welcome"] = "Selamat datang di SpareHub!",
                ["menu"] = "Silakan pilih menu utama:",
                ["order"] = "1. Sistem Pemesanan",
                ["store"] = "2. Kelola Toko",
                ["search"] = "3. Pencarian Produk",
                ["wishlist"] = "4. Wishlist",
                ["support"] = "5. Komunikasi / Keluhan",
                ["rating"] = "6. Ulasan & Rating Produk",
                ["exit"] = "7. Keluar",
                ["invalid"] = "Pilihan tidak valid.",
                ["bye"] = "Terima kasih telah menggunakan SpareHub!"
            },
            ["en"] = new Dictionary<string, string>
            {
                ["welcome"] = "Welcome to SpareHub!",
                ["menu"] = "Please choose a main menu option:",
                ["order"] = "1. Order System",
                ["store"] = "2. Manage Store",
                ["search"] = "3. Product Search",
                ["wishlist"] = "4. Wishlist",
                ["support"] = "5. Communication / Complaints",
                ["rating"] = "6. Reviews & Ratings",
                ["exit"] = "7. Exit",
                ["invalid"] = "Invalid choice.",
                ["bye"] = "Thank you for using SpareHub!"
            }
        };
    }

    private string T(string key)
    {
        return translations[config["language"]][key];
    }

    public void ShowMainMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine(T("welcome"));
            Console.WriteLine("==============================");
            Console.WriteLine(T("menu"));
            Console.WriteLine(T("order"));
            Console.WriteLine(T("store"));
            Console.WriteLine(T("search"));
            Console.WriteLine(T("wishlist"));
            Console.WriteLine(T("support"));
            Console.WriteLine(T("rating"));
            Console.WriteLine(T("exit"));
            Console.Write(">> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Order order = new Order();
                    order.ProcessOrder();
                    Pause();
                    break;
                case "2":
                    ShowPlaceholder("Kelola Toko / Manage Store");
                    break;
                case "3":
                    ShowPlaceholder("Pencarian Produk / Product Search");
                    break;
                case "4":
                    ShowPlaceholder("Wishlist");
                    break;
                case "5":
                    ShowPlaceholder("Komunikasi / Keluhan");
                    break;
                case "6":
                    ShowPlaceholder("Ulasan & Rating Produk");
                    break;
                case "7":
                    Console.WriteLine(T("bye"));
                    running = false;
                    break;
                default:
                    Console.WriteLine(T("invalid"));
                    Pause();
                    break;
            }
        }
    }

    private void ShowPlaceholder(string featureName)
    {
        Console.WriteLine($"\nFitur '{featureName}' belum diimplementasikan.");
        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadLine();
    }
}
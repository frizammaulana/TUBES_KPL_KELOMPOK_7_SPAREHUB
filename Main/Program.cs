using System;
using System.Collections.Generic;
using Searching;
using Main;

public class Program
{
    static void Main()
    {
        var data = new List<Sparepart>
        {
            new Sparepart { Nama = "Oli", Kategori = "Mesin", Merek = "Shell", KompatibelDengan = "Vario", Harga = 60000 },
            new Sparepart { Nama = "Busi", Kategori = "Kelistrikan", Merek = "Honda", KompatibelDengan = "Beat", Harga = 25000 }
        };
        var mesin = new SearchEngine<Sparepart>(data);
        var hasil = mesin.CariBerdasarkanKategori("Mesin");
        foreach (var item in hasil)
        {
            Console.WriteLine($"{item.Nama} - {item.Merek} - Rp{item.Harga}");
        }
    }
}

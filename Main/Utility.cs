using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class Utility
    {
        public static List<Sparepart> AmbilDataDummy()
        {
            return new List<Sparepart>
            {
                new Sparepart { Nama = "Oli", Kategori = "Mesin", Merek = "Shell", KompatibelDengan = "Vario", Harga = 60000 },
                new Sparepart { Nama = "Busi", Kategori = "Kelistrikan", Merek = "Honda", KompatibelDengan = "Beat", Harga = 25000 },
                new Sparepart { Nama = "Aki", Kategori = "Kelistrikan", Merek = "Yuasa", KompatibelDengan = "Vario", Harga = 150000 },
                new Sparepart { Nama = "Filter Udara", Kategori = "Mesin", Merek = "Aspira", KompatibelDengan = "Scoopy", Harga = 40000 },
                new Sparepart { Nama = "Kampas Rem", Kategori = "Rem", Merek = "Federal", KompatibelDengan = "Beat", Harga = 30000 },
                new Sparepart { Nama = "Rantai", Kategori = "Transmisi", Merek = "Sss", KompatibelDengan = "Supra X", Harga = 120000 },
                new Sparepart { Nama = "Lampu Depan", Kategori = "Kelistrikan", Merek = "Osram", KompatibelDengan = "NMAX", Harga = 85000 },
                new Sparepart { Nama = "Ban Belakang", Kategori = "Ban", Merek = "IRC", KompatibelDengan = "Vario", Harga = 200000 },
                new Sparepart { Nama = "Knalpot", Kategori = "Mesin", Merek = "R9", KompatibelDengan = "CB150R", Harga = 750000 },
                new Sparepart { Nama = "Speedometer", Kategori = "Kelistrikan", Merek = "Koso", KompatibelDengan = "Aerox", Harga = 550000 }
            };
        }
    }
}
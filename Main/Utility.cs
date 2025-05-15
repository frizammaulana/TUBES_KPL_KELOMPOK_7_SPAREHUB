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
                new Sparepart { Nama = "Speedometer", Kategori = "Kelistrikan", Merek = "Koso", KompatibelDengan = "Aerox", Harga = 550000 },
                new Sparepart { Nama = "Velg Racing", Kategori = "Roda", Merek = "TDR", KompatibelDengan = "Mio", Harga = 650000 },
                new Sparepart { Nama = "Rem Cakram", Kategori = "Rem", Merek = "Brembo", KompatibelDengan = "NMAX", Harga = 980000 },
                new Sparepart { Nama = "Shockbreaker", Kategori = "Suspensi", Merek = "YSS", KompatibelDengan = "PCX", Harga = 1150000 },
                new Sparepart { Nama = "Kabel Gas", Kategori = "Transmisi", Merek = "TK", KompatibelDengan = "Revo", Harga = 18000 },
                new Sparepart { Nama = "Kampas Kopling", Kategori = "Transmisi", Merek = "FCC", KompatibelDengan = "Vixion", Harga = 145000 },
                new Sparepart { Nama = "ECU Racing", Kategori = "Kelistrikan", Merek = "BRT", KompatibelDengan = "Aerox", Harga = 950000 },
                new Sparepart { Nama = "Ban Depan", Kategori = "Ban", Merek = "Zeneos", KompatibelDengan = "Mio", Harga = 185000 },
                new Sparepart { Nama = "Spion", Kategori = "Body", Merek = "KTC", KompatibelDengan = "CBR150R", Harga = 90000 },
                new Sparepart { Nama = "Cover Body", Kategori = "Body", Merek = "Original", KompatibelDengan = "Beat", Harga = 320000 },
                new Sparepart { Nama = "Radiator", Kategori = "Mesin", Merek = "AHM", KompatibelDengan = "CBR150R", Harga = 420000 },
                new Sparepart { Nama = "Garnish Lampu", Kategori = "Body", Merek = "Scarlet", KompatibelDengan = "XMAX", Harga = 125000 },
                new Sparepart { Nama = "Handle Rem", Kategori = "Rem", Merek = "KTC", KompatibelDengan = "PCX", Harga = 135000 },
                new Sparepart { Nama = "Windshield", Kategori = "Body", Merek = "Yamaha", KompatibelDengan = "Aerox", Harga = 180000 },
                new Sparepart { Nama = "Kabel Kopling", Kategori = "Transmisi", Merek = "Aspira", KompatibelDengan = "CB150R", Harga = 30000 },
                new Sparepart { Nama = "Oli Transmisi", Kategori = "Mesin", Merek = "Castrol", KompatibelDengan = "Scoopy", Harga = 45000 },
                new Sparepart { Nama = "Kick Starter", Kategori = "Transmisi", Merek = "Original", KompatibelDengan = "Revo", Harga = 55000 },
                new Sparepart { Nama = "CDI", Kategori = "Kelistrikan", Merek = "BRT", KompatibelDengan = "Jupiter Z", Harga = 320000 },
                new Sparepart { Nama = "Piston Kit", Kategori = "Mesin", Merek = "TDR", KompatibelDengan = "Vario", Harga = 250000 },
                new Sparepart { Nama = "Kabel Body", Kategori = "Kelistrikan", Merek = "Original", KompatibelDengan = "Vega R", Harga = 80000 },
                new Sparepart { Nama = "Lampu Sein", Kategori = "Kelistrikan", Merek = "Stanley", KompatibelDengan = "Beat", Harga = 25000 },
                new Sparepart { Nama = "Jok Motor", Kategori = "Body", Merek = "Yamaha", KompatibelDengan = "NMAX", Harga = 280000 },
                new Sparepart { Nama = "Switch Rem", Kategori = "Kelistrikan", Merek = "Aspira", KompatibelDengan = "Mio", Harga = 20000 },
                new Sparepart { Nama = "Karet CVT", Kategori = "Transmisi", Merek = "Honda", KompatibelDengan = "Vario", Harga = 50000 },
                new Sparepart { Nama = "Segitiga As", Kategori = "Roda", Merek = "Original", KompatibelDengan = "CBR150R", Harga = 150000 },
                new Sparepart { Nama = "Tutup Radiator", Kategori = "Mesin", Merek = "AHM", KompatibelDengan = "CB150R", Harga = 32000 },
                new Sparepart { Nama = "Magnet", Kategori = "Kelistrikan", Merek = "Denso", KompatibelDengan = "Scoopy", Harga = 275000 },
                new Sparepart { Nama = "Gear Set", Kategori = "Transmisi", Merek = "Sss", KompatibelDengan = "Vixion", Harga = 215000 },
                new Sparepart { Nama = "Dek Panel", Kategori = "Body", Merek = "Original", KompatibelDengan = "Mio", Harga = 140000 },
                new Sparepart { Nama = "Injector", Kategori = "Mesin", Merek = "Denso", KompatibelDengan = "Vario", Harga = 380000 },
                new Sparepart { Nama = "Thermostat", Kategori = "Mesin", Merek = "Koso", KompatibelDengan = "PCX", Harga = 90000 },
                new Sparepart { Nama = "Pegangan Belakang", Kategori = "Body", Merek = "KTC", KompatibelDengan = "XMAX", Harga = 170000 },
                new Sparepart { Nama = "Bearing", Kategori = "Roda", Merek = "SKF", KompatibelDengan = "Vega R", Harga = 40000 },
                new Sparepart { Nama = "Roller CVT", Kategori = "Transmisi", Merek = "RacingBoy", KompatibelDengan = "Aerox", Harga = 125000 },
                new Sparepart { Nama = "Kipas Radiator", Kategori = "Mesin", Merek = "Honda", KompatibelDengan = "CBR150R", Harga = 230000 },
                new Sparepart { Nama = "Kabel Rem", Kategori = "Rem", Merek = "Aspira", KompatibelDengan = "Supra X", Harga = 30000 },
                new Sparepart { Nama = "Seal Shock", Kategori = "Suspensi", Merek = "Showa", KompatibelDengan = "Vario", Harga = 35000 },
                new Sparepart { Nama = "Garnish Knalpot", Kategori = "Body", Merek = "R9", KompatibelDengan = "CB150R", Harga = 145000 },
                new Sparepart { Nama = "Lampu Belakang", Kategori = "Kelistrikan", Merek = "Stanley", KompatibelDengan = "Beat", Harga = 50000 },
                new Sparepart { Nama = "Ban Tubeless", Kategori = "Ban", Merek = "FDR", KompatibelDengan = "Aerox", Harga = 210000 },
                new Sparepart { Nama = "Saklar Stang", Kategori = "Kelistrikan", Merek = "Koso", KompatibelDengan = "CB150R", Harga = 87000 }
            };
        }
    }
}
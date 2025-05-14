using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Searching
{
    public interface ISparepart
    {
        string Nama { get; }
        string Kategori { get; }
        string Merek { get; }
        string KompatibelDengan { get; }
        decimal Harga { get; }
    }

    public class SearchEngine<T> where T : ISparepart
    {
        private List<T> daftarSparepart;
        private Dictionary<string, List<T>> tabelKategori;
        private Dictionary<string, List<T>> tabelMerek;

        public SearchEngine(List<T> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data sparepart tidak boleh null");

            daftarSparepart = data;
            tabelKategori = new Dictionary<string, List<T>>(StringComparer.OrdinalIgnoreCase);
            tabelMerek = new Dictionary<string, List<T>>(StringComparer.OrdinalIgnoreCase);

            BangunTabel();

            Debug.Assert(daftarSparepart.Count >= 0, "Daftar sparepart tidak boleh null");
            Debug.Assert(tabelKategori != null && tabelMerek != null, "Tabel tidak boleh null");
        }

        private void BangunTabel()
        {
            foreach (var item in daftarSparepart)
            {
                Debug.Assert(item != null, "Item dalam daftar tidak boleh null");

                if (!tabelKategori.ContainsKey(item.Kategori))
                    tabelKategori[item.Kategori] = new List<T>();
                tabelKategori[item.Kategori].Add(item);

                if (!tabelMerek.ContainsKey(item.Merek))
                    tabelMerek[item.Merek] = new List<T>();
                tabelMerek[item.Merek].Add(item);
            }
        }

        public List<T> CariBerdasarkanKategori(string kategori)
        {
            if (string.IsNullOrWhiteSpace(kategori))
                throw new ArgumentException("Kategori tidak boleh kosong", nameof(kategori));

            var hasil = tabelKategori.TryGetValue(kategori, out var list) ? list : new List<T>();

            Debug.Assert(hasil != null, "Hasil pencarian tidak boleh null");
            return hasil;
        }

        public List<T> CariBerdasarkanMerek(string merek)
        {
            if (string.IsNullOrWhiteSpace(merek))
                throw new ArgumentException("Merek tidak boleh kosong", nameof(merek));

            var hasil = tabelMerek.TryGetValue(merek, out var list) ? list : new List<T>();

            Debug.Assert(hasil != null, "Hasil pencarian tidak boleh null");
            return hasil;
        }

        public List<T> CariBerdasarkanKompatibilitas(string motor)
        {
            if (string.IsNullOrWhiteSpace(motor))
                throw new ArgumentException("Nama motor tidak boleh kosong", nameof(motor));

            var hasil = new List<T>();

            foreach (var item in daftarSparepart)
            {
                Debug.Assert(item != null, "Item tidak boleh null");

                if (item.KompatibelDengan.IndexOf(motor, StringComparison.OrdinalIgnoreCase) >= 0)
                    hasil.Add(item);
            }

            Debug.Assert(hasil != null, "Hasil pencarian tidak boleh null");
            return hasil;
        }
    }
}

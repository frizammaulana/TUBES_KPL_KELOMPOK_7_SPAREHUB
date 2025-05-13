using System;
using System.Collections.Generic;

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

        public SearchEngine(List<T> data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Data sparepart tidak boleh null");

            daftarSparepart = data;
        }

        public List<T> CariBerdasarkanKategori(string kategori)
        {
            if (string.IsNullOrEmpty(kategori))
                throw new ArgumentException("Kategori tidak boleh kosong", nameof(kategori));

            List<T> hasil = new List<T>();

            foreach (var item in daftarSparepart)
            {
                if (item.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase))
                {
                    hasil.Add(item);
                }
            }

            return hasil;
        }

        public List<T> CariBerdasarkanMerek(string merek)
        {
            if (string.IsNullOrEmpty(merek))
                throw new ArgumentException("Merek tidak boleh kosong", nameof(merek));

            List<T> hasil = new List<T>();

            foreach (var item in daftarSparepart)
            {
                if (item.Merek.Equals(merek, StringComparison.OrdinalIgnoreCase))
                {
                    hasil.Add(item);
                }
            }

            return hasil;
        }

        public List<T> CariBerdasarkanKompatibilitas(string motor)
        {
            if (string.IsNullOrEmpty(motor))
                throw new ArgumentException("Nama motor tidak boleh kosong", nameof(motor));

            List<T> hasil = new List<T>();

            foreach (var item in daftarSparepart)
            {
                if (item.KompatibelDengan.IndexOf(motor, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    hasil.Add(item);
                }
            }

            return hasil;
        }
    }
}

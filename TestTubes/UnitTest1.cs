using Mengelola_Toko.Models;
using Mengelola_Toko.Services;
using System;
using Xunit;

namespace Mengelola_Toko.Tests
{
    public class TokoServicesTests
    {
        [Fact]
        public void TambahBarang_ShouldAddBarangCorrectly()
        {
            var service = new TokoServices();

            var barang = new Barang
            {
                Nama = "Sproket",
                Deskripsi = "Gear motor belakang",
                Stok = 10,
                Harga = 150000

            };

            service.TambahBarang(barang);
            var semua = service.GetSemuaBarang();

            Assert.Single(semua);
            Assert.Equal("Sproket", semua[0].Nama);
            Assert.Equal("Gear motor belakang", semua[0].Deskripsi);
            Assert.Equal(10, semua[0].Stok);
        }

        [Fact]
        public void TambahBarang_WithInvalidData_ShouldThrowException()
        {
            var service = new TokoServices();

            var barang = new Barang
            {
                Nama = "",
                Deskripsi = "",
                Stok = -1,
                Harga = - 1

            };

            var ex = Record.Exception(() => service.TambahBarang(barang));

            Assert.NotNull(ex);
            Assert.Contains("Nama barang tidak boleh kosong", ex.Message);
        }

        [Fact]
        public void UbahDeskripsi_ShouldUpdateCorrectly()
        {
            var service = new TokoServices();
            var barang = new Barang
            {
                Nama = "Oli",
                Deskripsi = "Oli mesin",
                Stok = 5,
                Harga = 55000
            };

            service.TambahBarang(barang);
            var id = service.GetSemuaBarang()[0].Id;

            service.UbahDeskripsi(id, "Oli mesin full synthetic");

            Assert.Equal("Oli mesin full synthetic", service.GetSemuaBarang()[0].Deskripsi);
        }

        [Fact]
        public void HapusBarang_ShouldRemoveBarang()
        {
            var service = new TokoServices();
            var barang = new Barang
            {
                Nama = "Kampas Rem",
                Deskripsi = "Kampas depan",
                Stok = 3,
                Harga = 70000
            };

            service.TambahBarang(barang);
            var id = service.GetSemuaBarang()[0].Id;

            service.HapusBarang(id);

            Assert.Empty(service.GetSemuaBarang());
        }

        [Fact]
        public void LihatStok_ShouldReturnCorrectStok()
        {
            var service = new TokoServices();
            var barang = new Barang
            {
                Nama = "Busi",
                Deskripsi = "Busi NGK",
                Stok = 7,
                Harga = 150000
            };

            service.TambahBarang(barang);
            var id = service.GetSemuaBarang()[0].Id;

            int stok = service.LihatStok(id);

            Assert.Equal(7, stok);
        }
    }
}

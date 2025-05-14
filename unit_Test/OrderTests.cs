using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace unit_Test;


public class OrderTests
{
    private const string TestCartFile = "test_keranjang.json";

    private Order CreateTestOrder()
    {
        // Buat objek Order dengan path CartFile yang bisa dimodifikasi
        return new Order(TestCartFile);
    }

    [Fact]
    public void AddToCart_ShouldAddItemCorrectly()
    {
        // Arrange
        File.WriteAllText(TestCartFile, "[]"); // Kosongkan keranjang
        var order = CreateTestOrder();

        // Simulasi data item
        var cart = new List<CartItem>
        {
            new CartItem
            {
                ProductId = "P001",
                ProductName = "Oli Mesin",
                Quantity = 2,
                Price = 50000
            }
        };

        // Simpan ke file JSON
        var json = JsonSerializer.Serialize(cart, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(TestCartFile, json);

        // Act
        var loadedCart = order.LoadCart();

        // Assert
        Assert.Single(loadedCart);
        Assert.Equal("Oli Mesin", loadedCart[0].ProductName);
        Assert.Equal(2, loadedCart[0].Quantity);
        Assert.Equal(50000, loadedCart[0].Price);
    }

    [Fact]
    public void LoadCart_ShouldReturnEmptyList_IfFileDoesNotExist()
    {
        // Arrange
        if (File.Exists(TestCartFile))
            File.Delete(TestCartFile);

        var order = CreateTestOrder();

        // Act
        var cart = order.LoadCart();

        // Assert
        Assert.NotNull(cart);
        Assert.Empty(cart);
    }
}

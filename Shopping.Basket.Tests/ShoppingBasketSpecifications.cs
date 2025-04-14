using FluentAssertions;
using Shopping.Basket.Domain;

namespace Shopping.Basket.Tests;

public class ShoppingBasketSpecifications
{
    [Fact]
    public void Debe_existir_una_ShoppingBasket_vacia_y_al_obtener_su_precio_total_debe_ser_0()
    {
        var shoppingBasket = new ShoppingBasket();

        var precioTotal = shoppingBasket.ObtenerPrecioTotal();

        precioTotal.Should().Be(0);
    }

    [Fact]
    public void Debe_arrojar_un_ArgumentException_cuando_intentan_agregar_un_producto_con_precio_negativo()
    {
        var shoppingBasket = new ShoppingBasket();

        var caller = () => shoppingBasket.AgregarProducto(new Producto("Canela", -1000, 1));

        caller.Should().ThrowExactly<ArgumentException>()
            .WithMessage("El precio del producto tiene que ser mayor a 0.");
    }

    [Fact]
    public void Debe_arrojar_un_ArgumentException_cuando_intentan_agregar_un_producto_con_precio_0()
    {
        var shoppingBasket = new ShoppingBasket();

        var caller = () => shoppingBasket.AgregarProducto(new Producto("Canela", 0, 0));

        caller.Should().ThrowExactly<ArgumentException>()
            .WithMessage("El precio del producto tiene que ser mayor a 0.");
    }

    [Fact]
    public void Debe_arrojar_un_ArgumentException_cuando_intentan_agregar_un_producto_con_cantidad_negativa()
    {
        var shoppingBasket = new ShoppingBasket();

        var caller = () => shoppingBasket.AgregarProducto(new Producto(
            "Canela", 1000, -1));

        caller.Should().ThrowExactly<ArgumentException>()
            .WithMessage("La cantidad del producto tiene que ser mayor a 0.");
    }

    [Fact]
    public void Debe_arrojar_un_ArgumentException_cuando_intentan_agregar_un_producto_con_cantidad_0()
    {
        var shoppingBasket = new ShoppingBasket();

        var caller = () => shoppingBasket.AgregarProducto(new Producto("Canela", 1000, 0));

        caller.Should().ThrowExactly<ArgumentException>()
            .WithMessage("La cantidad del producto tiene que ser mayor a 0.");
    }

    [Fact]
    public void Debe_una_ShoppingBasket_aceptar_un_producto_su_precio_y_cantidad()
    {
        var shoppingBasket = new ShoppingBasket();
        shoppingBasket.AgregarProducto(new Producto("Canela", 1000, 1));

        var productos = shoppingBasket.ObtenerProductos();

        productos.Should().HaveCount(1);
    }
}
namespace Shopping.Basket.Domain;

public class ShoppingBasket
{
    private List<Producto> _productos { get; set; } = [];

    public object ObtenerPrecioTotal()
    {
        return 0;
    }

    public void AgregarProducto(Producto producto)
    {
        ValidarProducto(producto);

        _productos.Add(producto);
    }

    private static void ValidarProducto(Producto producto)
    {
        if (producto.Precio <= 0)
            throw new ArgumentException("El precio del producto tiene que ser mayor a 0.");

        if (producto.Cantidad is < 0 or 0)
            throw new ArgumentException("La cantidad del producto tiene que ser mayor a 0.");
    }

    public IReadOnlyList<Producto> ObtenerProductos()
    {
        return _productos.AsReadOnly();
    }
}
public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
    public override string ToString()
    {
        return $"Name: {_name}, Product ID: {_productId}, Price: ${_price}, Quantity: {_quantity}";
    }

}
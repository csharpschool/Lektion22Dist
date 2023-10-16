namespace Lektion22Dist.Classes;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public double Price { get; set; }
    public double Vat { get; set; }
    public double Total => Price + Price * Vat;

    public Product(int id, string name, int categoryId,
        double price, double vat) 
        => (Id, Name, CategoryId, Price, Vat) 
        = (id, name, categoryId, price, vat);
    
}

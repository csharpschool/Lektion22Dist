namespace Lektion22Dist.Classes;

public class Store
{
    List<Category> categories = new();
    List<Product> products = new();
    const int MAX_PAGE_SIZE = 2;
    public List<Product> Products { get; private set; }
    public int PageCount => products.Count / MAX_PAGE_SIZE;
    public int Counter { get; set; } = 0;
    public Store()
    {
        SeedCategories();
        SeedProducts();
        GetProducts();
    }

    private void SeedCategories()
    {
        categories.Add(new Category(1, "Electronics"));
        categories.Add(new Category(2, "Food"));
        categories.Add(new Category(3, "Books"));
    }
    private void SeedProducts()
    {
        try
        {
            var electronics = categories.SingleOrDefault(c => c.Name == "Electronics");
            if(electronics != null)
            {
                products.Add(new Product(1001, "TV", electronics.Id, 10, 0.25));
                products.Add(new Product(1002, "Toaster", electronics.Id, 100, 0.25));
                products.Add(new Product(1003, "Radio", electronics.Id, 1000, 0.25));
            }

            var food = categories.SingleOrDefault(c => c.Name == "Food");
            if (food != null)
            {
                products.Add(new Product(1004, "Fish", food.Id, 200, 0.25));
                products.Add(new Product(1005, "Bread", food.Id, 20, 0.25));
                products.Add(new Product(1006, "Bread Crumbs", food.Id, 2, 0.25));
            }

        }
        catch
        {
        }
    }

    public void GetProducts() => Products = products;
    public void GetProducts(Func<Product, bool> lambda) 
        => Products = products.Where(lambda).ToList();
    public void GetProducts(int page) => 
        Products = products.Skip((page - 1) * MAX_PAGE_SIZE).Take(MAX_PAGE_SIZE).ToList();

    public string GetCategoryName(int id)
    {
        var name = categories.SingleOrDefault(c => c.Id == id)?.Name;
        
        return name ?? string.Empty;
    }

    public List<Category> GetCategories() => categories;
}

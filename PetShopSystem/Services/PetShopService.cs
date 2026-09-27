using Microsoft.EntityFrameworkCore;
using PetShopSystem.Data;
using PetShopSystem.Entities;
namespace PetShopSystem.Services;
public class PetShopService
{
    private readonly AppDbContext _context;
    public PetShopService(AppDbContext context)
    {
        _context = context;
    }
    public void AddProduct(Product product)
    {
        if (_context.Products.Any(x => x.Id == product.Id))
        {
            Console.WriteLine("Bu Id ile mehsul artig movcuddu");
            return;
        }
        if (product.Price <= 0)
        {
            Console.WriteLine("Giymet 0 dan boyuy olmalidi");
            return;
        }
        if (product.Stock < 0)
        {
            Console.WriteLine("Stok menfi ola bilmez.");
            return;
        }
        _context.Products.Add(product);
        _context.SaveChanges();
        Console.WriteLine("Mehsul ugurla elave edildi.");
    }
    public void ShowAllProducts()
    {
        var products = _context.Products.ToList();
        if (products.Count == 0)
        {
            Console.WriteLine("Mehsul yoxdur.");
            return;
        }
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
    public Product? FindProductById(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }
    public void DeleteProduct(int id)
    {
        Product? product = FindProductById(id);
        if (product == null)
        {
            Console.WriteLine("Mehsul tapilmadi.");
            return;
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        Console.WriteLine("Mehsul ugurla silindi");
    }
    public void AddCustomer(Customer customer)
    {
        if (_context.Customers.Any(x => x.Id == customer.Id))
        {
            Console.WriteLine("Bu Id ile musteri artiq movcuddur.");
            return;
        }
        if (customer.Age <= 0)
        {
            Console.WriteLine("Yash 0 dan boyuy olmalidi");
            return;
        }
        _context.Customers.Add(customer);
        _context.SaveChanges();
        Console.WriteLine("Mushteri ugurla elave edildi.");
    }
    public void ShowAllCustomers()
    {
        var customers = _context.Customers.ToList();
        if (customers.Count == 0)
        {
            Console.WriteLine("Mushteri yoxdur.");
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }
    public Customer? FindCustomerById(int id)
    {
        return _context.Customers.FirstOrDefault(x => x.Id == id);
    }
    public void BuyProduct(int orderId, int customerId, int productId, int quantity)
    {
        Product? product = FindProductById(productId);
        Customer? customer = FindCustomerById(customerId);

        if (product == null)
        {
            Console.WriteLine("Mehsul tapilmadi.");
            return;
        }
        if (customer == null)
        {
            Console.WriteLine("Mushteri tapilmadi.");
            return;
        }
        if (quantity <= 0)
        {
            Console.WriteLine("Miqdar sifirdan boyuk olmalidir.");
            return;
        }
        if (product.Stock < quantity)
        {
            Console.WriteLine("Kifayet qeder mehsul yoxdur.");
            return;
        }
        if (_context.Orders.Any(x => x.Id == orderId))
        {
            Console.WriteLine("Bu Id ile sifaris artiq movcuddur.");
            return;
        }
        decimal totalPrice = product.Price * quantity;
        Order order = new(orderId,customerId,productId, quantity, totalPrice);
        product.Stock -= quantity;
        _context.Orders.Add(order);
        _context.SaveChanges();
        Console.WriteLine("Mehsul ugurla alindi.");
        Console.WriteLine($"Umumi mebleg: {totalPrice}");
    }
    public void ShowAllOrders()
    {
        var orders = _context.Orders.ToList();
        if (orders.Count == 0)
        {
            Console.WriteLine("Sifarish yoxdu");
            return;
        }
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
    public Order? FindOrderById(int id)
    {
        return _context.Orders.FirstOrDefault(x => x.Id == id);
    }
    public void CancelOrder(int id)
    {
        Order? order = FindOrderById(id);
        if (order == null)
        {
            Console.WriteLine("Sifarish tapilmadi.");
            return;
        }
        Product? product = FindProductById(order.ProductId);
        if (product != null)
        {
            product.Stock += order.Quantity;
        }
        _context.Orders.Remove(order);
        _context.SaveChanges();
        Console.WriteLine("Sifarish ugurla legv edildi");
    }
    public void ShowCustomerOrders(int customerId)
    {
        Customer? customer = FindCustomerById(customerId);
        if (customer == null)
        {
            Console.WriteLine("Mushteri tapilmadi.");
            return;
        }
        var orders = _context.Orders.Where(x => x.CustomerId == customerId).ToList();
        if (orders.Count == 0)
        {
            Console.WriteLine("Bu mushterinin sifarisi yoxdur.");
            return;
        }
        Console.WriteLine($"Musteri: {customer.Name}");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
    public void ShowProductOrders(int productId)
    {
        Product? product = FindProductById(productId);
        if (product == null)
        {
            Console.WriteLine("Mehsul tapilmadi.");
            return;
        }
        var orders = _context.Orders.Where(x => x.ProductId == productId).ToList();
        if (orders.Count == 0)
        {
            Console.WriteLine("Bu mehsul ucun sifarish yoxdur.");
            return;
        }
        Console.WriteLine($"Mehsul: {product.Name}");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}
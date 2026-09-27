using PetShopSystem.Data;
using PetShopSystem.Entities;
using PetShopSystem.Services;
AppDbContext context = new();
//context.Database.EnsureDeleted(); // 1. Удалит старую заблокированную базу
context.Database.EnsureCreated(); // 2. Создаст абсолютно чистую и правильную

PetShopService service = new(context);

while (true)
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("+==========================================================+");
    Console.WriteLine("|                                                          |");
    Console.WriteLine("|                 P E T   S H O P                          |");
    Console.WriteLine("|                    S Y S T E M                           |");
    Console.WriteLine("|                                                          |");
    Console.WriteLine("+==========================================================+");

    Console.ResetColor();

    Console.WriteLine();
    Console.WriteLine("+-------------------------+  +----------------------------+");
    Console.WriteLine("|       MEHSULLER         |  |        MUSTERILER          |");
    Console.WriteLine("+-------------------------+  +----------------------------+");
    Console.WriteLine("| [1] Mehsul elave et     |  | [5] Musteri elave et       |");
    Console.WriteLine("| [2] Butun mehsulleri    |  | [6] Butun musterileri      |");
    Console.WriteLine("|     goster              |  |     goster                 |");
    Console.WriteLine("| [3] Mehsul tap          |  | [7] Musteri tap            |");
    Console.WriteLine("| [4] Mehsul sil          |  |                            |");
    Console.WriteLine("+-------------------------+  +----------------------------+");

    Console.WriteLine();

    Console.WriteLine("+----------------------------------------------------------+");
    Console.WriteLine("|                    S I F A R I S L E R                   |");
    Console.WriteLine("+----------------------------------------------------------+");
    Console.WriteLine("|                                                          |");
    Console.WriteLine("| [8]  Mehsul al                  [11] Sifarisi legv et    |");
    Console.WriteLine("| [9]  Butun sifarisleri goster   [12] Musteri sifarisleri |");
    Console.WriteLine("| [10] Sifaris tap                [13] Mehsul sifarisleri   |");
    Console.WriteLine("|                                                          |");
    Console.WriteLine("+----------------------------------------------------------+");

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("+----------------------------------------------------------+");
    Console.WriteLine("|                 [0] PROQRAMDAN CIX                       |");
    Console.WriteLine("+----------------------------------------------------------+");
    Console.ResetColor();

    Console.WriteLine();
    Console.Write(">> Seciminiz: ");

    string? choice = Console.ReadLine();

    Console.Clear();

    switch (choice)
    {
        case "1":
            ShowTitle("MEHSUL ELAVE ET");

            Console.Write("Mehsul Id: ");
            int productId = int.Parse(Console.ReadLine()!);

            Console.Write("Mehsul adi: ");
            string productName = Console.ReadLine()!;

            Console.WriteLine();
            Console.WriteLine("+-----------------------------+");
            Console.WriteLine("|         KATEQORIYA          |");
            Console.WriteLine("+-----------------------------+");
            Console.WriteLine("| 1. Yem                      |");
            Console.WriteLine("| 2. Oyuncaq                  |");
            Console.WriteLine("| 3. Derman                   |");
            Console.WriteLine("| 4. Aksesuar                 |");
            Console.WriteLine("+-----------------------------+");

            Console.Write("Kateqoriya secin: ");
            int categoryChoice = int.Parse(Console.ReadLine()!);

            Category category = (Category)categoryChoice;

            Console.Write("Qiymet: ");
            decimal price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Stok: ");
            int stock = int.Parse(Console.ReadLine()!);

            Product product = new(
                productId,
                productName,
                category,
                price,
                stock);

            Console.WriteLine();

            service.AddProduct(product);
            Pause();
            break;

        case "2":
            ShowTitle("BUTUN MEHSULLER");

            service.ShowAllProducts();

            Pause();
            break;

        case "3":
            ShowTitle("MEHSUL TAP");

            Console.Write("Mehsul Id: ");
            int findProductId = int.Parse(Console.ReadLine()!);

            Product? foundProduct =
                service.FindProductById(findProductId);

            Console.WriteLine();

            if (foundProduct == null)
            {
                Console.WriteLine("Mehsul tapilmadi.");
            }
            else
            {
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("|                     MEHSUL MELUMATI                      |");
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine(foundProduct);
                Console.WriteLine("+----------------------------------------------------------+");
            }

            Pause();
            break;

        case "4":
            ShowTitle("MEHSUL SIL");

            Console.Write("Silinecek mehsul Id: ");
            int deleteProductId = int.Parse(Console.ReadLine()!);

            Console.WriteLine();

            service.DeleteProduct(deleteProductId);

            Pause();
            break;

        case "5":
            ShowTitle("MUSTERI ELAVE ET");

            Console.Write("Musteri Id: ");
            int customerId = int.Parse(Console.ReadLine()!);

            Console.Write("Musteri adi: ");
            string customerName = Console.ReadLine()!;

            Console.Write("Yas: ");
            int age = int.Parse(Console.ReadLine()!);

            Customer customer = new(
                customerId,
                customerName,
                age);

            Console.WriteLine();

            service.AddCustomer(customer);

            Pause();
            break;

        case "6":
            ShowTitle("BUTUN MUSTERILER");

            service.ShowAllCustomers();

            Pause();
            break;

        case "7":
            ShowTitle("MUSTERI TAP");

            Console.Write("Musteri Id: ");
            int findCustomerId = int.Parse(Console.ReadLine()!);

            Customer? foundCustomer =
                service.FindCustomerById(findCustomerId);

            Console.WriteLine();

            if (foundCustomer == null)
            {
                Console.WriteLine("Musteri tapilmadi.");
            }
            else
            {
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("|                    MUSTERI MELUMATI                      |");
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine(foundCustomer);
                Console.WriteLine("+----------------------------------------------------------+");
            }

            Pause();
            break;

        case "8":
            ShowTitle("MEHSUL AL");

            Console.Write("Sifaris Id: ");
            int orderId = int.Parse(Console.ReadLine()!);

            Console.Write("Musteri Id: ");
            int orderCustomerId = int.Parse(Console.ReadLine()!);

            Console.Write("Mehsul Id: ");
            int orderProductId = int.Parse(Console.ReadLine()!);

            Console.Write("Miqdar: ");
            int quantity = int.Parse(Console.ReadLine()!);

            Console.WriteLine();

            service.BuyProduct(
                orderId,
                orderCustomerId,
                orderProductId,
                quantity);

            Pause();
            break;

        case "9":
            ShowTitle("BUTUN SIFARISLER");

            service.ShowAllOrders();

            Pause();
            break;

        case "10":
            ShowTitle("SIFARIS TAP");

            Console.Write("Sifaris Id: ");
            int findOrderId = int.Parse(Console.ReadLine()!);

            Order? foundOrder =
                service.FindOrderById(findOrderId);

            Console.WriteLine();

            if (foundOrder == null)
            {
                Console.WriteLine("Sifaris tapilmadi.");
            }
            else
            {
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine("|                    SIFARIS MELUMATI                      |");
                Console.WriteLine("+----------------------------------------------------------+");
                Console.WriteLine(foundOrder);
                Console.WriteLine("+----------------------------------------------------------+");
            }

            Pause();
            break;

        case "11":
            ShowTitle("SIFARISI LEGv ET");

            Console.Write("Legv edilecek sifaris Id: ");
            int cancelOrderId = int.Parse(Console.ReadLine()!);

            Console.WriteLine();

            service.CancelOrder(cancelOrderId);

            Pause();
            break;

        case "12":
            ShowTitle("MUSTERININ SIFARISLERI");

            Console.Write("Musteri Id: ");
            int ordersCustomerId = int.Parse(Console.ReadLine()!);

            Console.WriteLine();

            service.ShowCustomerOrders(ordersCustomerId);

            Pause();
            break;

        case "13":
            ShowTitle("MEHSULUN SIFARISLERI");

            Console.Write("Mehsul Id: ");
            int ordersProductId = int.Parse(Console.ReadLine()!);

            Console.WriteLine();

            service.ShowProductOrders(ordersProductId);

            Pause();
            break;

        case "0":
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("+==========================================================+");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|             PET SHOP SISTEMINDEN CIXIS                   |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|                 Tesekkur edirik!                         |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("+==========================================================+");

            Console.ResetColor();

            return;

        default:
            Console.WriteLine();
            Console.WriteLine("+----------------------------------------------------------+");
            Console.WriteLine("|                  YANLIS SECIM!                           |");
            Console.WriteLine("|             Zehmet olmasa tekrar edin.                   |");
            Console.WriteLine("+----------------------------------------------------------+");

            Pause();
            break;
    }
}

static void ShowTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("+==========================================================+");
    Console.WriteLine($"|                  {title,-38} |");
    Console.WriteLine("+==========================================================+");

    Console.ResetColor();

    Console.WriteLine();
}

static void Pause()
{
    Console.WriteLine();
    Console.WriteLine("+----------------------------------------------------------+");
    Console.WriteLine("|           Davam etmek ucun ENTER basin...                |");
    Console.WriteLine("+----------------------------------------------------------+");

    Console.ReadLine();
}
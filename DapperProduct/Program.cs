using DapperProduct.DataAccess;
using DapperProduct.Domain.Entities;

namespace ProductDB
{
    internal class Program
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        static void Main(string[] args)
        {
            var productRepo = new ProductRepository(connectionString);

            try
            {
                while (true)
                {
                    Console.WriteLine("===== PRODUCT MENU =====");
                    Console.WriteLine("1 - Butun mehsullari goster");
                    Console.WriteLine("2 - Id ile mehsul tap");
                    Console.WriteLine("3 - Yeni mehsul elave et");
                    Console.WriteLine("4 - Mehsulu yenile");
                    Console.WriteLine("5 - Mehsulu sil");
                    Console.WriteLine("0 - Cixis");
                    Console.Write("Secim et: ");

                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            var products = productRepo.GetAll();
                            foreach (var p in products)
                            {
                                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Quantity: {p.Quantity}, Description: {p.Description}");
                            }
                            break;

                        case "2":
                            Console.Write("Id daxil et: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            var product = productRepo.GetById(searchId);
                            if (product != null)
                            {
                                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Description: {product.Description}");
                            }
                            else
                            {
                                Console.WriteLine("Bu Id ile mehsul tapilmadi...");
                            }
                            break;

                        case "3":
                            Console.Write("Name: ");
                            string? name = Console.ReadLine();

                            Console.Write("Price: ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Description: ");
                            string? description = Console.ReadLine();

                            var newProduct = new Product()
                            {
                                Name = name,
                                Price = price,
                                Quantity = quantity,
                                Description = description
                            };
                            productRepo.Add(newProduct);
                            break;

                        case "4":
                            Console.Write("Yenilenecek mehsulun Id-si: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            var updateProduct = productRepo.GetById(updateId);

                            if (updateProduct != null)
                            {
                                Console.Write("Yeni Name: ");
                                updateProduct.Name = Console.ReadLine();

                                Console.Write("Yeni Price: ");
                                updateProduct.Price = Convert.ToDecimal(Console.ReadLine());

                                Console.Write("Yeni Quantity: ");
                                updateProduct.Quantity = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Yeni Description: ");
                                updateProduct.Description = Console.ReadLine();

                                productRepo.Update(updateProduct);
                            }
                            else
                            {
                                Console.WriteLine("Bu Id ile mehsul tapilmadi...");
                            }
                            break;

                        case "5":
                            Console.Write("Silinecek mehsulun Id-si: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            var deleteProduct = productRepo.GetById(deleteId);

                            if (deleteProduct != null)
                            {
                                productRepo.Delete(deleteProduct);
                            }
                            else
                            {
                                Console.WriteLine("Bu Id ile mehsul tapilmadi...");
                            }
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Yanlis secim, yeniden cehd edin...");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ ex.Message);
            }
        }
    }
}
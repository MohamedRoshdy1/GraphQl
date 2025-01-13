using GraphQlTask.Data.Model;

namespace GraphQlTask.Data.Seeding;

public static class DatabaseSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Description = "High performance laptop", Price = 1000.00, CreationDate = DateTime.Now },
                new Product { Name = "Smartphone", Description = "Latest model smartphone", Price = 700.00, CreationDate = DateTime.Now },
                new Product { Name = "Tablet", Description = "10-inch screen tablet", Price = 300.00, CreationDate = DateTime.Now },
                new Product { Name = "Monitor", Description = "24-inch HD monitor", Price = 150.00, CreationDate = DateTime.Now },
                new Product { Name = "Keyboard", Description = "Mechanical keyboard", Price = 80.00, CreationDate = DateTime.Now },
                new Product { Name = "Mouse", Description = "Wireless optical mouse", Price = 40.00, CreationDate = DateTime.Now },
                new Product { Name = "Headphones", Description = "Noise-cancelling headphones", Price = 200.00, CreationDate = DateTime.Now },
                new Product { Name = "Smartwatch", Description = "Fitness tracking smartwatch", Price = 250.00, CreationDate = DateTime.Now },
                new Product { Name = "Camera", Description = "Digital SLR camera", Price = 500.00, CreationDate = DateTime.Now },
                new Product { Name = "Printer", Description = "All-in-one printer", Price = 120.00, CreationDate = DateTime.Now },
                new Product { Name = "Desk", Description = "Ergonomic office desk", Price = 300.00, CreationDate = DateTime.Now },
                new Product { Name = "Chair", Description = "Comfortable office chair", Price = 150.00, CreationDate = DateTime.Now },
                new Product { Name = "External Hard Drive", Description = "1TB external hard drive", Price = 90.00, CreationDate = DateTime.Now },
                new Product { Name = "Router", Description = "WiFi 6 router", Price = 180.00, CreationDate = DateTime.Now },
                new Product { Name = "Webcam", Description = "HD webcam", Price = 70.00, CreationDate = DateTime.Now },
                new Product { Name = "Speakers", Description = "Bluetooth speakers", Price = 120.00, CreationDate = DateTime.Now },
                new Product { Name = "Gaming Console", Description = "Next-gen gaming console", Price = 500.00, CreationDate = DateTime.Now },
                new Product { Name = "TV", Description = "55-inch 4K TV", Price = 600.00, CreationDate = DateTime.Now },
                new Product { Name = "Projector", Description = "Home cinema projector", Price = 400.00, CreationDate = DateTime.Now },
                new Product { Name = "Microwave", Description = "800W microwave oven", Price = 100.00, CreationDate = DateTime.Now }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
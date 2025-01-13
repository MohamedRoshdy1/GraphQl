using GraphQlTask.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GraphQlTask.Data.Services;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }
    public IEnumerable<Product> GetProductsWithPaginationAndOrdering(int first, int skip, string orderBy, string orderDirection)
    {
        var query = _context.Products.AsQueryable();

        // Apply dynamic ordering
        query = orderBy.ToLower() switch
        {
            "name" => orderDirection.ToLower() == "desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
            "description" => orderDirection.ToLower() == "desc" ? query.OrderByDescending(p => p.Description) : query.OrderBy(p => p.Description),
            "price" => orderDirection.ToLower() == "desc" ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
            _ => orderDirection.ToLower() == "desc" ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id), // Default ordering by Id
        };

        // Apply pagination
        return query.Skip(skip).Take(first).ToList();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.Where(d => d.Id == id).FirstOrDefault();
    }
    public Product AddProduct(Product product)
    {
        product.CreationDate = DateTime.Now;
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }
    public Product? UpdateProduct(int id, Product product)
    {
        var _product = _context.Products.Where(d => d.Id == id).FirstOrDefault();
        if (_product != null)
        {
            _product.Name = product.Name;
            _product.Description = product.Description;
            _product.Price = product.Price;
        }
        _context.SaveChanges();
        return _product;
    }
    public void DeleteProduct(int id)
    {
        var _product = _context.Products.Where(d => d.Id == id).FirstOrDefault();
        if (_product != null)
        {
            _context.Products.Remove(_product);
            _context.SaveChanges();
        }
    }
}


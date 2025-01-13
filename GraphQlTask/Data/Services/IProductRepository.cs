using GraphQlTask.Data.Model;

namespace GraphQlTask.Data.Services;
public interface IProductRepository
{
    Product AddProduct(Product product);
    void DeleteProduct(int id);
    List<Product> GetAllProducts();
    IEnumerable<Product> GetProductsWithPaginationAndOrdering(int first, int skip, string orderBy, string orderDirection);
    Product? GetProductById(int id);
    Product? UpdateProduct(int id, Product product);
}
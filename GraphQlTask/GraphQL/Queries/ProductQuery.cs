using GraphQL;
using GraphQL.Types;
using GraphQlTask.Data.Services;
using GraphQlTask.GraphQL.Types;

namespace GraphQlTask.GraphQL.Queries;

public class ProductQuery : ObjectGraphType
{
    public ProductQuery(IProductRepository repository)
    {
        // Query to get all products with pagination
        Field<ListGraphType<ProductType>>(
            "products",
            "Return all the products with pagination and optional ordering",
            arguments: new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "first", Description = "Number of products to return" },
                new QueryArgument<IntGraphType> { Name = "skip", Description = "Number of products to skip" },
                new QueryArgument<StringGraphType> { Name = "orderBy", Description = "Field to order by (e.g., 'id', 'name', 'price')" },
                new QueryArgument<StringGraphType> { Name = "orderDirection", Description = "Order direction ('asc' or 'desc')" }
            ),
            resolve: context =>
            {
                var first = context.GetArgument<int?>("first") ?? 10; // Default to 10
                var skip = context.GetArgument<int?>("skip") ?? 0;    // Default to 0
                var orderBy = context.GetArgument<string>("orderBy") ?? "id"; // Default to ordering by 'id'
                var orderDirection = context.GetArgument<string>("orderDirection") ?? "asc"; // Default to ascending order

                return repository.GetProductsWithPaginationAndOrdering(first, skip, orderBy, orderDirection);
            }
        );


        Field<ProductType>(
            "product",
            "Return a single product by id",
            new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product Id" }),
            resolve: context => repository.GetProductById(context.GetArgument("id", int.MinValue)));
    }
}
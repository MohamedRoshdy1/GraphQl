using GraphQL;
using GraphQL.Types;
using GraphQlTask.Data.Model;
using GraphQlTask.Data.Services;
using GraphQlTask.GraphQL.Types;

namespace GraphQlTask.GraphQL.Mutations;

public class ProductMutation : ObjectGraphType
{
    public ProductMutation(IProductRepository repository)
    {
        Field<ProductType>(
            "addProduct",
            "Is used to add a new product to the database",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product", Description = "Product input parameter." }
            ),
            resolve: context =>
            {
                var product = context.GetArgument<Product>("product");
                if (product != null)
                {
                    return repository.AddProduct(product);
                }
                return null;
            });

        Field<ProductType>(
           "updateProduct",
           "Is used to update an existing product in the database",
           arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Id of the product that needs to be updated" },
               new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product", Description = "Product input parameter." }
           ),
           resolve: context =>
           {
               var id = context.GetArgument<int>("id");
               var product = context.GetArgument<Product>("product");
               if (product != null)
               {
                   return repository.UpdateProduct(id, product);
               }
               return null;
           });

        Field<ProductType>(
          "deleteProduct",
          "Is used to delete an existing product from the database",
          arguments: new QueryArguments(
              new QueryArgument<NonNullGraphType<IdGraphType>>
              {
                  Name = "id",
                  Description = "Id of the product that needs to be deleted"
              }
          ),
          resolve: context =>
          {
              var id = context.GetArgument<int>("id");
              repository.DeleteProduct(id);
              return true;
          });
    }

}

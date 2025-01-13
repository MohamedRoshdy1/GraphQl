using GraphQL.Types;

namespace GraphQlTask.GraphQL.Mutations;

public class ProductInputType : InputObjectGraphType
{
    public ProductInputType()
    {
        Name = "ProductInputType";
        Field<NonNullGraphType<StringGraphType>>("Name", description: "The name of the product.");
        Field<StringGraphType>("Description", description: "The description of the product.");
        Field<NonNullGraphType<FloatGraphType>>("Price", description: "The price of the product.");
    }
}

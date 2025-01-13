using GraphQL.Types;
using GraphQlTask.Data.Model;

namespace GraphQlTask.GraphQL.Types;

public class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(d => d.Id, type: typeof(IdGraphType)).Description("Id property for Product object");
        Field(d => d.Name, type: typeof(StringGraphType)).Description("Name property for Product object");
        Field(d => d.Description, type: typeof(StringGraphType)).Description("Description property for Product object");
        Field(d => d.Price, type: typeof(FloatGraphType)).Description("Price property for Product object");
        Field(d => d.CreationDate, type: typeof(DateTimeGraphType)).Description("CreateDate property for Product object");

    }
}
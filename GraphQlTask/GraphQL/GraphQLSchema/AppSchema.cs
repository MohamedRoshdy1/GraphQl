using GraphQL.Types;
using GraphQlTask.GraphQL.Mutations;
using GraphQlTask.GraphQL.Queries;

namespace GraphQlTask.GraphQL.GraphQLSchema;

public class AppSchema : Schema
{
    public AppSchema(ProductQuery query, ProductMutation mutation)
    {
        this.Query = query;
        this.Mutation = mutation;
    }
}
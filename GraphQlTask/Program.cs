
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQlTask.Data;
using GraphQlTask.Data.Model;
using GraphQlTask.Data.Seeding;
using GraphQlTask.Data.Services;
using GraphQlTask.GraphQL.GraphQLSchema;
using GraphQlTask.GraphQL.Mutations;
using GraphQlTask.GraphQL.Queries;
using GraphQlTask.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphQlTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IProductRepository,ProductRepository>();
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //graphql config
        builder.Services.AddGraphQL().AddSystemTextJson();
        builder.Services.AddScoped<ProductQuery>();
        builder.Services.AddScoped<ProductMutation>();
        builder.Services.AddScoped<AppSchema>();




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}
        //graphql
        app.UseGraphQL<AppSchema>();
        app.UseGraphQLGraphiQL("/ui/graphql");
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        // Apply migrations and seed data
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
            DatabaseSeeder.SeedData(dbContext);
        }
      
        app.Run();
    }
}

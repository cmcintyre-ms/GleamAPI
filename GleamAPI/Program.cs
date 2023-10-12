using GleamAPI.Data;
using GleamAPI.Interfaces;
using GleamAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using GleamAPI.GraphQL.Queries;
using GleamAPI.GraphQL.Mutations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using GleamAPI.GraphQL.Reviews;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
    {
        //sqlOptions.EnableRetryOnFailure();
    });
});

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddInMemorySubscriptions();

builder.Services.AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<GleamVenueQueries>()
        .AddTypeExtension<ReviewQueries>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddTypeExtension<GleamVenueMutations>()
        .AddTypeExtension<ReviewMutations>();

builder.Services.AddTransient<IGleamVenueRepository, GleamVenueRepository>();
builder.Services.AddScoped<GleamVenueRepository, GleamVenueRepository>();

builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ReviewRepository, ReviewRepository>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

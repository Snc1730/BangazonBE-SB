using BangazonBE_SB.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using BangazonBE_SB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonDBContext>(builder.Configuration["BangazonDbConnectionString"]);


// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Orders

// Get all orders
app.MapGet("/api/Orders", (BangazonDBContext db) =>
{
    return db.Orders.ToList();
});

// Get a single order
app.MapGet("/api/OrderDetails", (BangazonDBContext db, int OrderId) =>
{
    var getOrder = db.Orders.FirstOrDefault(order => order.OrderId == OrderId);
    return getOrder;
}
);

// Delete Order
app.MapDelete("/api/order/{id}", (BangazonDBContext db, int id) =>
{
    Orders order = db.Orders.SingleOrDefault(order => order.OrderId == id);
    if (order == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.NoContent();

});

// Update Order
app.MapPut("/api/Order/{id}", (BangazonDBContext db, int id, Orders order) =>
{
    Orders OrderToUpdate = db.Orders.SingleOrDefault(order => order.OrderId == id);
    if (OrderToUpdate == null)
    {
        return Results.NotFound();
    }
    OrderToUpdate.StatusId = order.StatusId;

    db.SaveChanges();
    return Results.NoContent();
});

// OrderStatus

// Get all order status
app.MapGet("/api/OrderStatuses", (BangazonDBContext db) =>
{
    return db.OrderStatuses.ToList();
});


// PaymentTypes

// Get all PaymentTypes
app.MapGet("/api/PaymentTypes", (BangazonDBContext db) =>
{
    return db.PaymentTypes.ToList();
});

// ProductCategories
// Get all ProductCategories
app.MapGet("/api/ProductCategories", (BangazonDBContext db) =>
{
    return db.ProductCategories.ToList();
});

// Products

// Get all Products
app.MapGet("/api/Products", (BangazonDBContext db) =>
{
    return db.Products.ToList();
});

// Get a single seller's Products
app.MapGet("/api/sllersproducts/{userId}", (BangazonDBContext db, int id) =>
{
    var product = db.Products.Where(product => product.UserId == id).ToList();
    return product;
});

// Update Product
app.MapPut("/api/Products/{id}", (BangazonDBContext db, int id, Products product) =>
{
    Products productToUpdate = db.Products.SingleOrDefault(product => product.ProductId == id);
    if (productToUpdate == null)
    {
        return Results.NotFound();
    }
    productToUpdate.Name = product.Name;
    productToUpdate.Price = product.Price;

    db.SaveChanges();
    return Results.NoContent();
});

// Add a Product
app.MapPost("/api/products", (BangazonDBContext db, Products product) =>
{
    db.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/api/products/{product.ProductId}", product);
});

// Delete a Product
app.MapDelete("/api/product/{id}", (BangazonDBContext db, int id) =>
{
    Products product = db.Products.SingleOrDefault(product => product.ProductId == id);
    if (product == null)
    {
        return Results.NotFound();
    }
    db.Products.Remove(product);
    db.SaveChanges();
    return Results.NoContent();

});

// Users

// Get all users
app.MapGet("/api/Users", (BangazonDBContext db) =>
{
    return db.Users.ToList();
});

// Get user by ID
app.MapGet("/api/user/{id}", (BangazonDBContext db, int id) =>
{
    var user = db.Users.Single(user => user.UserId == id);
    return user;
});

// Add a User
app.MapPost("/api/user", (BangazonDBContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/api/user/{user.UserId}", user);
});

// Update User
app.MapPut("/api/user/{id}", (BangazonDBContext db, User user, int id) =>
{
    User userToUpdate = db.Users.SingleOrDefault(user => user.UserId == id);
    if (userToUpdate == null)
    {
        return Results.NotFound();
    }
    userToUpdate.Name = user.Name;
    userToUpdate.IsSeller = user.IsSeller;

    db.SaveChanges();
    return Results.Created($"/api/user/{user.UserId}", user);
});

//Delete a User
app.MapDelete("/api/user/{id}", (BangazonDBContext db, int id) =>
{
    User user = db.Users.SingleOrDefault(user => user.UserId == id);
    if (user == null)
    {
        return Results.NotFound();
    }
    db.Users.Remove(user);
    db.SaveChanges();
    return Results.NoContent();

});

// Users_PaymentTypes

// Get all UserPaymentTypes
app.MapGet("/api/Users_PaymentTypes", (BangazonDBContext db) =>
{
    return db.Users_PaymentTypes.ToList();
});

app.Run();

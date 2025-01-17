using Microsoft.EntityFrameworkCore;
using Petstore.Server.Data;
using Petstore.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PetstoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetstoreDatabase")));

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PetstoreContext>();

    // Apply migrations if they are not applied yet
    context.Database.Migrate();

    // Seed additional data if not already seeded
    SeedData(context);
}


app.UseDefaultFiles();
app.UseStaticFiles();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

// Method to seed additional data
void SeedData(PetstoreContext context)
{
    // Check if Pets exist; if not, add them
    if (!context.Pets.Any())
    {
        var tags = context.Tags.ToList();

        var pets = new List<Pet>
        {
            new Pet { Name = "Charlie", Status = "available", Tags = new List<Tag> { tags[0], tags[1] } },
            new Pet { Name = "Lucy", Status = "pending", Tags = new List<Tag> { tags[2] } },
            new Pet { Name = "Milo", Status = "sold", Tags = new List<Tag> { tags[3] } }
        };

        context.Pets.AddRange(pets);
        context.SaveChanges();
    }

    // Check if Tags exist; if not, add them
    if (!context.Tags.Any())
    {
        var tags = new List<Tag>
        {
            new Tag { Name = "Energetic" },
            new Tag { Name = "Cuddly" },
            new Tag { Name = "Adventurous" }
        };

        context.Tags.AddRange(tags);
        context.SaveChanges();
    }
}
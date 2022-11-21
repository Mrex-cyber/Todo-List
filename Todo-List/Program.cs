using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
string connection = "Server=(localdb)\\mssqllocaldb;Database=applicationdb;Trusted_Connection=True;";
builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/items", async (AppContext app) => await app.Items.ToListAsync());

app.MapPost("/api/items", async (Item item, AppContext app) =>
{
    await app.Items.AddAsync(item);
    await app.SaveChangesAsync();
    return item;
});

app.Run();

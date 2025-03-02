using EmployeeRegister.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Adatbázis kapcsolat beállítása
builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 2. ASP.NET Core MVC és Razor Pages engedélyezése
builder.Services.AddControllersWithViews(); // <-- Ezt adjuk hozzá az MVC-hez!
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); //fejlesztői hibaoldalt
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 🔹 3. Beállítjuk az alapértelmezett útvonalat (MVC Controller-ekhez)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

// 🔹 4. Razor Pages engedélyezése (ha még kell)
app.MapRazorPages();

app.Run();

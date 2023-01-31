using CarShop.Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CarShop.Data;
using CarShop.Data.Repository;
using CarShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
builder.Services.AddTransient<IShopCartItem, ItemReposytory>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseSession();
//app.UseMvcWithDefaultRoute();
app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller="Car", action="List"});
});

var a = (IApplicationBuilder) app;
using (var scope = a.ApplicationServices.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}

    app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

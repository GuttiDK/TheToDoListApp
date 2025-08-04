using Microsoft.EntityFrameworkCore;
using TheToDoListApp.Repository.Domain;
using TheToDoListApp.Repository.Interfaces;
using TheToDoListApp.Repository.Repositories;
using TheToDoListApp.Service.Interfaces;
using TheToDoListApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<MappingService>();

builder.Services.AddSingleton<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddSingleton<IToDoItemService, ToDoItemService>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ToDoListContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging();
}, ServiceLifetime.Singleton);


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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

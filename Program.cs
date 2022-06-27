using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using StorePrototype.Data;
using StorePrototype.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Service for emulating a bank account
builder.Services.AddSingleton<Accounts>();
//Service for emulating a DB of items
builder.Services.AddSingleton<StoreItems>();
//Service for emulating store cart data
builder.Services.AddSingleton<Carts>();
//Service for emulating a db of receipts
builder.Services.AddSingleton<ReceiptList>();
builder.Services.AddSingleton<ListUpdateService>();
builder.Services.AddSingleton<LoginServices>();
builder.Services.AddSingleton<DebugAccountService>();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

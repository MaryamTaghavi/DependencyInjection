using DependencyInjectionLifeTime.MiddleWares;
using DependencyInjectionLifeTime.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<TransientService>();
//builder.Services.AddTransient(typeof(TransientService));

builder.Services.AddSingleton<SingletonService>();

//TryAdd اگر از قبل موجود باشه اولی را انتخاب میکند در صورتی که Try رو نگذاریم آخری را انتخاب میکند.
//builder.Services.TryAddScoped<SingletonService>();

//builder.Services.AddSingleton(new SingletonService());

builder.Services.AddScoped<ScopedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseMiddleware<LifeTimeMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

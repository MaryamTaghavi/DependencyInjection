using LifeTime2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lifetime validation
// با فعال کردن این گزینه سبب میشود که لایف تایم ها دقیقتر بررسی شوند یعنی قانون رعایت شود
// اونی که تزریق میشه باید لایف تایمش کوچیک تر باشد
// به عبارت دیگر سرویس اصلی باید لایف تایم طولانی تری داشته باشد

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = true; 
});

builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

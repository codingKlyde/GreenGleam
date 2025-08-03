using GreenGleam.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
    options.UseSqlServer(connectionString);
});

builder.Services
    .AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services
    .AddTransient<AuthService>()
    .AddTransient<OrderService>()
    .AddTransient<ProductService>()
    .AddTransient<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapAuthEndpoints().MapOrderEndpoints().MapProductEndpoints().MapUserEndpoints();

app.Run();
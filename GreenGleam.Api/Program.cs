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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var issuer = builder.Configuration.GetValue<string>("Jwt:Issuer");

    var key = builder.Configuration.GetValue<string>("Jwt:Key");
    var securityKey = Encoding.UTF8.GetBytes(key);
    var symmetricKey = new SymmetricSecurityKey(securityKey);

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = symmetricKey,
        ValidateAudience = false,
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    AutoMigrateDatabase(app.Services);
}
app.UseHttpsRedirection();
app.MapControllers();


app.UseAuthentication().UseAuthorization();

app.MapAuthEndpoints().MapOrderEndpoints().MapProductEndpoints().MapUserEndpoints();

app.Run();


// Use only during development
static void AutoMigrateDatabase(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
}
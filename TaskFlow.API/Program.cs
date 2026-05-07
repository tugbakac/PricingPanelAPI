using TaskFlow.API.Middlewares;
using TaskFlow.Application.DependencyInjection;
using TaskFlow.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// =========================
// SERVICES
// =========================
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("MerchantId", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "merchant-id",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Merchant ID header"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "MerchantId"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5174")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Clean Architecture DI
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// =========================
// MIDDLEWARE PIPELINE
// =========================

// 1. GLOBAL ERROR HANDLING (EN DIÞ KATMAN)
app.UseMiddleware<ExceptionMiddleware>();

// 2. HTTPS REDIRECTION
app.UseHttpsRedirection();


app.UseCors("AllowFrontend");
// 3. SWAGGER (SADECE DEV)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4. TENANT / MERCHANT CONTEXT
app.UseMiddleware<MerchantMiddleware>();

// 5. AUTHORIZATION (ileride auth eklenirse hazýr)
app.UseAuthorization();

// 6. ROUTING
app.MapControllers();

app.Run();

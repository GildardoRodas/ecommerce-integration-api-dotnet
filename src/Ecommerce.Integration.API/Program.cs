using Ecommerce.Integration.Application.Auth;
using Ecommerce.Integration.Application.Auth.Login;
using Ecommerce.Integration.Application.Orders;
using Ecommerce.Integration.Application.Orders.CreateOrder;
using Ecommerce.Integration.Application.Orders.GetOrderById;
using Ecommerce.Integration.Application.Payments;
using Ecommerce.Integration.Application.Payments.CreatePaymentIntent;
using Ecommerce.Integration.Application.Payments.HandlePaymentWebhook;
using Ecommerce.Integration.Application.Payments.ProcessPayment;
using Ecommerce.Integration.Application.Shipping;
using Ecommerce.Integration.Application.Shipping.CreateShipment;
using Ecommerce.Integration.Application.Shipping.HandleShippingWebhook;
using Ecommerce.Integration.Infrastructure.Persistence;
using Ecommerce.Integration.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Ecommerce Integration API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese el token JWT en este formato: Bearer {tu_token}"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

builder.Services.AddAuthorization();



// Orders DI
builder.Services.AddSingleton<IOrderRepository,InMemoryOrderRepository>();
builder.Services.AddTransient<CreateOrderHandler>();
builder.Services.AddTransient<GetOrderByIdHandler>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<LoginHandler>();
builder.Services.AddSingleton<IPaymentRepository, InMemoryPaymentRepository>();
builder.Services.AddTransient<CreatePaymentIntentHandler>();
builder.Services.AddTransient<ProcessPaymentHandler>();
builder.Services.AddTransient<PaymentWebhookHandler>();
builder.Services.AddSingleton<IShipmentRepository, InMemoryShipmentRepository>();
builder.Services.AddTransient<CreateShipmentHandler>();
builder.Services.AddTransient<ShippingWebhookHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var ADMIN_CORS_POLICY = "ADMIN_CORS_POLICY";
var OTHERS_CORS_POLICY = "OTHERS_CORS_POLICY";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ADMIN_CORS_POLICY,
        builder =>
        {
            builder
            .WithOrigins("https://localhost:2476", "https://localhost:5006", "https://localhost:7006", "https://localhost:59601")
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
            ;
        });

    options.AddPolicy(name: OTHERS_CORS_POLICY,
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
            ;
        });
});

//Add services to the container();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.MaxDepth = 5;
    //options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;



    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
//========================================================================================

builder.Services.AddDbContext<Data.DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManaConnectionString"));
});

//builder.Services.AddDbContext<Data.DatabaseContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ManaConnectionString"))
//           .LogTo(Console.WriteLine, LogLevel.Information)
//           ;
//});

//========================================================================================
//builder.Services.AddControllers();
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.MaxDepth = 2;
//    options.SerializerOptions.PropertyNamingPolicy = null;
//    options.SerializerOptions.IgnoreReadOnlyProperties = true;

//    options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    options.SerializerOptions.WriteIndented = true;
//});
//========================================================================================




//builder.Services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>(sp =>
//{
//    Data.Tools.Options options =
//        new Data.Tools.Options
//        {
//            Provider =
//                (Data.Tools.Enums.Provider)
//                Convert.ToInt32(builder.Configuration.GetSection(key: "DatabaseProvider").Value),

//            ConnectionString =
//            builder.Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "ManaConnectionString").Value,

//        };
//    return new Data.UnitOfWork(options: options);

//});

//SignalR================================================================================

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
//=======================================================================================

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true

        };
    });




var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName: ADMIN_CORS_POLICY);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<Server.Hubs.ChatHub>("/chathub");

app.Run();

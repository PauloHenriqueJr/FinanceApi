using ApiStone.Data;
using FinanceApi.Repository.Interfaces;
using FinanceApi.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

#region main snippet
// Add services to the container.
string mySqlConnection =
builder.Configuration.GetConnectionString("ConnectionAccount");
builder.Services.AddDbContextPool<FinanceDbContext>(opt =>
opt.UseLazyLoadingProxies().UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<AccountService, AccountService>();
builder.Services.AddScoped<IDepositService, DepositService>();
builder.Services.AddScoped<IWithdrawService, WithdrawService>();
builder.Services.AddScoped<IStatementService, StatementService>();
builder.Services.AddScoped<IBalanceService, BalanceService>();
//builder.Services.AddScoped<TransferService, TransferService>();
//builder.Services.AddScoped<LoginService, LoginService>();
//builder.Services.AddScoped<RegisterService, RegisterService>();
//builder.Services.AddScoped<RefreshTokenService, RefreshTokenService>();
//builder.Services.AddScoped<LogoutService, LogoutService>();
//builder.Services.AddScoped<RecoverPasswordService, RecoverPasswordService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() 
    {
        Title = "Customer Finance Api",
        Version = "v1", 
        Description = "Project developed as a challenge - ASP.NET Core Web API by Paulo Henrique",
        Contact = new OpenApiContact
        {
            Name = "Project on github",
            Url = new Uri("https://github.com/PauloHenriqueJr/FinanceApi")
        },
        License = new OpenApiLicense
        {
            Name = "Project License",
            Url = new Uri("https://github.com/PauloHenriqueJr/FinanceApi/blob/master/LICENSE.txt")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    
});
var app = builder.Build();

#endregion main snippet

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

//app.UseAuthorization();

app.MapControllers();

app.Run();

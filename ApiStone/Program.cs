using ApiStone.Data;
using ApiStone.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnection =
builder.Configuration.GetConnectionString("ConnectionAccount");
builder.Services.AddDbContextPool<AccountDbContext>(opt =>
opt.UseLazyLoadingProxies().UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<AccountService, AccountService>();
builder.Services.AddScoped<StatementService, StatementService>();
builder.Services.AddScoped<DepositService, DepositService>();
builder.Services.AddScoped<WithdrawService, WithdrawService>();
builder.Services.AddScoped<BalanceService, BalanceService>();
//builder.Services.AddScoped<TransferService, TransferService>();
//builder.Services.AddScoped<LoginService, LoginService>();
//builder.Services.AddScoped<RegisterService, RegisterService>();
//builder.Services.AddScoped<RefreshTokenService, RefreshTokenService>();
//builder.Services.AddScoped<LogoutService, LogoutService>();
//builder.Services.AddScoped<RecoverPasswordService, RecoverPasswordService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

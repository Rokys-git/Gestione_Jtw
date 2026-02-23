using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, //significa che se issuer == la stringa che definisco allora puo passare
        ValidateAudience = true,
        ValidateLifetime = true,//metto una scadenza al token
        ValidateIssuerSigningKey = true,//
        ValidIssuer = "mio sito",
        ValidAudience = "indirizzo api",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("corso_talentform!corso_talentform")//dobbiamo superare i 256 bit
            )
    };
});
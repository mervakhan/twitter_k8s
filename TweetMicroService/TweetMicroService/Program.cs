using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TweetMicroService.DbContexts;
using TweetMicroService.Services;
using TweetMicroService.Services.Interfaces;
using TweetMicroService.Utilities;

var builder = WebApplication.CreateBuilder(args);
var dbPassword = SecretManager.GetSecretKey("SqlPassword");
var conString = builder.Configuration.GetConnectionString("DefaultConnection");
conString = string.Format(conString, dbPassword);

builder.Services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(conString));
builder.Services.AddDbContext<TweetsContext>(options =>
            options.UseSqlServer(conString));
builder.Services.AddDbContext<CommentsContext>(options =>
            options.UseSqlServer(conString));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.IncludeErrorDetails = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretManager.GetSecretKey("OAuthSecretKey"))), // Ensure this matches token creation
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
// Add services to the container.

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

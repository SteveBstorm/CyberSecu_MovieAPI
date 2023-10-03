using CyberSecu_MovieAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MovieAPI_DAL.Repos;
using MovieAPI_DAL.Services;
using System.Data;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var connectionString = $"Data Source={dbHost};Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";

builder.Services.AddTransient<IDbConnection, SqlConnection>(sp => 
    new SqlConnection(
        builder.Configuration.GetConnectionString("default")
        ));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddScoped<TokenGenerator>();

//D�claration des diff�rents niveaux de s�curit� � mettre en place dans le
//controller gr�ce � l'attribut [Authorize("nom_de_la_police")]
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminPolicy", option => option.RequireRole("Admin"));
    o.AddPolicy("ModoPolicy", option => option.RequireRole("Admin", "Modo"));
    o.AddPolicy("UserPolicy", option => option.RequireAuthenticatedUser());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenGenerator.secretKey)),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });


builder.Services.AddCors(o => o.AddPolicy("myPolicy", options =>
        options.WithOrigins("http://localhost:4200", "http://monsite.com")
               .AllowAnyMethod()
               .AllowCredentials()
               .AllowAnyHeader()
    ));


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
//app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//Wildcard => Porte ouverte, on autorise tout
app.UseCors("myPolicy");

app.MapControllers();

app.Run();

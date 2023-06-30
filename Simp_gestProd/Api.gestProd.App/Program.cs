using Api.gestProd.Data.Context;
using Api.gestProd.Data.Entity;
using Api.gestProd.Data.Repository;
using Api.gestProd.Data.Repository.Contract;
using Api.GestProd.Business.Services;
using Api.GestProd.Business.Services.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Connexion à la BDD
string connectionString = configuration.GetConnectionString("BddConnection");
builder.Services.AddDbContext<IGestProdDBContext, GestProdDBContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Add services to the container.


//IOC des repository
builder.Services.AddScoped<IAdressRepo, AdressRepo>();
builder.Services.AddScoped<IAviRepo, AviRepo>();
builder.Services.AddScoped<ICaracteristiqueRepo, CaracteristiqueRepo>();
builder.Services.AddScoped<ICategoriserRepo, CategoriserRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICodePostalRepo, CodePostalRepo>();
builder.Services.AddScoped<ICommanderRepo, CommanderRepo>();
builder.Services.AddScoped<ICompteRepo, CompteRepo>();
builder.Services.AddScoped<IDroitRepo, DroitRepo>();
builder.Services.AddScoped<IEtreRepo, EtreRepo>();
builder.Services.AddScoped<IExpeditionRepo, ExpeditionRepo>();
builder.Services.AddScoped<IIllustrerRepo, IllustrerRepo>();
builder.Services.AddScoped<IImageRepo, ImageRepo>();
builder.Services.AddScoped<INoteRepo, NoteRepo>();
builder.Services.AddScoped<IOptionRepo, OptionRepo>();
builder.Services.AddScoped<IPrixRepo, PrixRepo>();
builder.Services.AddScoped<IProduitRepo, ProduitRepo>();
builder.Services.AddScoped<IProfiterRepo, ProfiterRepo>();
builder.Services.AddScoped<IPromotionRepo, PromotionRepo>();
builder.Services.AddScoped<IPromouvoirRepo, PromouvoirRepo>();
builder.Services.AddScoped<IRemiseRepo, RemiseRepo>();
builder.Services.AddScoped<ISituerRepo, SituerRepo>();
builder.Services.AddScoped<IStatusRepo, StatusRepo>();
builder.Services.AddScoped<IStockRepo, StockRepo>();
builder.Services.AddScoped<IVilleRepo, VilleRepo>();

//IOC des services
builder.Services.AddScoped<IProduitService, ProduitService>();

builder.Services.AddControllers();
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

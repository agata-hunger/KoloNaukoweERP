using BLL.Services.Koordynator;
using BLL.Services.Lider;
using BLL.Services.Sekretarz;
using BLL.Services.Uzytkownik;
using BLL.Services.ZastepcaPrzewodniczacego;
using DAL;
using DAL.Entities;
using DAL.Repositories.CzlonekR;
using DAL.Repositories.PelnionaFunkcjaR;
using DAL.Repositories.ProjektR;
using DAL.Repositories.SprzetR;
using DAL.Repositories.WydarzenieR;
using DAL.Repositories.ZespolR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbKoloNaukoweERP>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICzlonekRepository, CzlonekRepository>();
builder.Services.AddScoped<IPelnionaFunkcjaRepository, PelnionaFunkcjaRepository>();
builder.Services.AddScoped<IProjektRepository, ProjektRepository>();
builder.Services.AddScoped<ISprzetRepository, SprzetRepository>();
builder.Services.AddScoped<IWydarzenieRepository, WydarzenieRepository>();
builder.Services.AddScoped<IZespolRepository, ZespolRepository>();

builder.Services.AddScoped<ISekretarzServices, SekretarzeServices>();
builder.Services.AddScoped<IPrzewodniczacyServices, PrzewodniczacyServices>();
builder.Services.AddScoped<IKoordynatorServices, KoordynatorServices>();
builder.Services.AddScoped<IUzytkownikServices, UzytkownikServices>();
builder.Services.AddScoped<ILiderServices, LiderServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
/*app.UseMiddleware<ErrorHandlingMiddleware>();*/
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//app.MapControllers();

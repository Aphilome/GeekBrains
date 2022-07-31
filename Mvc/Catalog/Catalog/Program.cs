using Catalog.Services.Abstract;
using Catalog.Services.Concrete;
using MailKit.Net.Smtp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
 * 1. В рамках каждого запроса будет заново производиться регистрация, что обеспечит каждый раз актуальность сессии
 * 2. В будущем даст возможность регистрироваться в разные учетки и серверы в разных параллельных запросах
 * 3. Вроде как в документации не сказано, что он потокобезопасный
 */
builder.Services.AddScoped<SmtpClient>();
builder.Services.AddScoped<IMailSender, MailSender>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Catalog.Configs;
using Catalog.Services.Abstract;
using Catalog.Services.Concrete;
using MailKit.Net.Smtp;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up!");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.Configure<SmtpCredentials>(builder.Configuration.GetSection("SmtpCredentials"));

    builder.Services.AddScoped<SmtpClient>();
    builder.Services.AddScoped<IMailSender, SmtpMailSender>();
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
}
catch (Exception ex)
{
    // TODO: Remove it in .NET 7
    if (ex.GetType().Name is "StopTheHostException")
    {
        throw;
    }
    Log.Fatal(ex, "HUSTON!!!");
    throw;
}
finally
{
    Log.Information("Good buy");
    Log.CloseAndFlush();
}
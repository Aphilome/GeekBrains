using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Restaurant.Notification;

CreateHostBuilder(args).Build().Run();


IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
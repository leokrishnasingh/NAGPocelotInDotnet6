using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

//  IConfiguration configuration = new ConfigurationBuilder()
//                              .AddJsonFile("ocelot.development.json")
//                              .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) => {
  config.AddJsonFile($"ocelot.{context.HostingEnvironment.EnvironmentName}.json",true,true);
});

builder.Services.AddOcelot();
builder.Services.AddOcelot().AddConsul();
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseOcelot().Wait();

app.Run();

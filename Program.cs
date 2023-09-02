var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services and configuration here

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


// Configure your application-specific middleware components here

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "csv",
        pattern: "csv/export",
        defaults: new { controller = "Csv", action = "ExportCsv" }); // Add this route
});

app.Run();


using Microsoft.EntityFrameworkCore;
using ProjectEmployeeManagement.Data;
using ProjectEmployeeManagement.Models;

var builder = WebApplication.CreateBuilder(args);


#region ConfigureServices
//1- Add MVC Services
builder.Services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
//3- dependency injection
//builder.Services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
//4- DbContextPool
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnectionStrings")));
////5- dependency injection  --> Database   
builder.Services.AddScoped<IEmployeeRepository,SqlEmployeeRepository>();
#endregion




var app = builder.Build();


#region Middleware
//2- Add Middleware Mvc
if (app.Environment.IsDevelopment())
    {
    app.UseDeveloperExceptionPage();
    }
/////////////////////////////////

app.UseStatusCodePagesWithRedirects("/Error/{0}");
/////////////////////////////////
app.UseExceptionHandler("/ErrorException");
/////////////////////////////////

app.UseRouting(); 
app.UseMvc(Route =>
{
    Route.MapRoute(name: "default", template: "{controller=home}/{action=index}/{id?}");
});
//app.UseMvcWithDefaultRoute();
app.UseStaticFiles();
app.Run();
#endregion
/////////////////////////////////

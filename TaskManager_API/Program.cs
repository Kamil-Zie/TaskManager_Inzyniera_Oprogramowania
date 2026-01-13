using TaskManager_API.Models;
using TaskManager_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors(o => o.AddPolicy("Allow", builder =>
{
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

// Configure TaskManager Database Settings 
builder.Services.Configure<TaskManagerDataBaseSettings>(
    builder.Configuration.GetSection("TaskManagerDatabase"));

//TaskManager Routing Service
builder.Services.AddSingleton<TaskManagerService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

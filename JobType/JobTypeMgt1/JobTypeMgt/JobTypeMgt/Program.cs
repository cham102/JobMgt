using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JobTypeMgt.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<JobTypeMgtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobTypeMgtContext") ?? throw new InvalidOperationException("Connection string 'JobTypeMgtContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<JobTypeMgtContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

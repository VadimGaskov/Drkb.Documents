using Drkb.JwtConfiguration.DI;
using Drkb.Documents.Infrastructure.DI;
using Drkb.Documents.Infrastructure.LoggerConfiguration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCorsPolicies();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddJwtGeneration();
builder.Services.AddBehavior();
builder.Services.AddMediatr();
builder.Services.AddSwagger();

builder.Services.AddSerilogLogger();
Log.Logger = SerilogConfiguration.GetSerilogConfiguration(builder.Configuration);
builder.Host.UseSerilog();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger()
        .UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "DrkbNews");
            options.RoutePrefix = string.Empty;
        });
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowFrontend");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
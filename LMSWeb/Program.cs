using veripark.ConfigurationSettings;
using veripark.Infrastructure.Impl;
using veripark.Infrastructure;
using veripark.UnitofWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

var ConnString = builder.Configuration.GetConnectionString("DefaultConnection");
ConnectionString.ConfigurationService(ConnString.ToString());
RegisterSercies(builder.Services);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
builder.Services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//New
app.UseCookiePolicy();
app.UseAuthentication();

app.Run();
void RegisterSercies(IServiceCollection services)
{


    //services.AddScoped<IAutoMapperProfile, AutoMapperProfile>();
    services.AddScoped<ILmsImpl, LmsImpl>();
    services.AddScoped<IUnitofWork, UnitofWork>();
    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IRoleService, RoleService>();

}

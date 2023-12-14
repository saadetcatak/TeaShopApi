using TeaShopApi.DataAccessLayer.Context;
using TeaShopApi.EntityLayer.Concrete;
using TeaShopApi.WebUI.Models;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TeaContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
//client iþlemi için yazýyoruz.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<TeaContext>().AddErrorDescriber<CustomIdentityValidator>();



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
//area iþlemi için ScaffoldingReadMeden yazýyoruz.

app.Run();

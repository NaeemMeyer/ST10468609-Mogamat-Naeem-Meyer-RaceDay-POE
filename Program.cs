using RaceDayMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC Services
builder.Services.AddControllersWithViews();

// HttpClient for API Communication
builder.Services.AddHttpClient<ApiService>();

// Session Configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Required for Session Helpers
builder.Services.AddHttpContextAccessor();

// Azure / Services
builder.Services.AddSingleton<BlobStorageService>();

var app = builder.Build();

// Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// MVC Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Docker Support
app.Urls.Add("http://0.0.0.0:80");

app.Run();

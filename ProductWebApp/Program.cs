using Polly;
using ProductWebApp.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IProductService, ProductService>();
//HttpClient with retry policy
builder.Services.AddHttpClient("ProductService", x =>
{
    x.BaseAddress = new Uri(builder.Configuration.GetConnectionString("ProductApiUrl"));
}).AddTransientHttpErrorPolicy(policyBuilder => 
policyBuilder.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Product/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{query?}"
    //pattern: "{controller=Home}/{action=Index}/{id?}"
    );


app.Run();

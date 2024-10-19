WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<Applicationdbcontext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
            .EnableServiceProviderCaching()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
.EnableThreadSafetyChecks()
);
builder.Services.AddScoped<IUnitOfWork, UnitofWork>();

//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[] { "en-US", "ar" };
//    options.SetDefaultCulture("en-US");
//    options.AddSupportedCultures(supportedCultures);
//    options.AddSupportedUICultures(supportedCultures);
//});

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//IOptions<RequestLocalizationOptions>? localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
//app.UseRequestLocalization(localizationOptions.Value);

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

using GameMatcher.Components;

var builder = WebApplication.CreateBuilder(args);

// Gets the Steam API key specified in 'secrets.json' file.
var steamApiKey = builder.Configuration["Steam:ServiceApiKey"];

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Allows for calling external web APIs
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

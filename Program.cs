using AIContentCreatorApp.Components;
using Google.GenAI;
using Syncfusion.Blazor;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

builder.Services.AddSyncfusionBlazor();

string googleApiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY", EnvironmentVariableTarget.User)
    ?? throw new InvalidOperationException("GOOGLE_API_KEY environment variable is required.");

builder.Services.AddSingleton(new Client(apiKey: googleApiKey));
WebApplication app = builder.Build();

string syncfusionLicenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_KEY", EnvironmentVariableTarget.User)
    ?? throw new InvalidOperationException("SYNCFUSION_KEY environment variable is required.");

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionLicenseKey);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

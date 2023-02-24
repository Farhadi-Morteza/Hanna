global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;
global using Extensions;
using Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;
using System.Globalization;
using Client.Services;
using Client.Infrastructure;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Authentication----------------------------------------------------------------------------
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
//------------------------------------------------------------------------------------------

//Add MudBlazor component-------------------------------------------------------------------
builder.Services.AddMudServices();
//builder.Services.AddMudServices( config =>
//{
//    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomLeft;

//    config.SnackbarConfiguration.PreventDuplicates = false;
//    config.SnackbarConfiguration.NewestOnTop = false;
//    config.SnackbarConfiguration.ShowCloseIcon = true;
//    config.SnackbarConfiguration.VisibleStateDuration = 10000;
//    config.SnackbarConfiguration.HideTransitionDuration = 500;
//    config.SnackbarConfiguration.ShowTransitionDuration = 500;
//    config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Outlined;  
//});
//------------------------------------------------------------------------------------------

//Add Our Services -------------------------------------------------------------------------
//builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<PrincipalBusinessService>();
builder.Services.AddScoped<BusinessService>();
builder.Services.AddScoped<BusinessTypeService>();  
builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<ActivityIndicatorService>(); 
builder.Services.AddScoped<ProductService>();   
builder.Services.AddScoped<ProductIndicatorService>(); 
builder.Services.AddScoped<ProductTypeService>();   

builder.Services.AddScoped<MetricService>();
builder.Services.AddScoped<YearService>();

builder.Services.AddScoped<CompanyCategoryService>();
builder.Services.AddScoped<CompanyService>();

builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<ActivityPlanService>();
builder.Services.AddScoped<ProductActivityPlanService>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ChatMessageService>();
//------------------------------------------------------------------------------------------


//Multi Language ---------------------------------------------------------------------------
//await builder.Build().RunAsync();
builder.Services.AddLocalization();

var host = builder.Build();

CultureInfo culture;
var js = host.Services.GetRequiredService<IJSRuntime>();
var result = await js.InvokeAsync<string>("blazorCulture.get");

if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await js.InvokeVoidAsync("blazorCulture.set", "en-US");
}

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
//------------------------------------------------------------------------------------------

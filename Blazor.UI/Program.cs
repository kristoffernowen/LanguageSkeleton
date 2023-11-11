using Blazor.UI;
using Blazor.UI.Services.Nouns;
using Blazor.UI.Services.Sentence;
using Blazor.UI.Services.Verbs;
using LanguageSkeleton.Blazor.UI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri(
    "https://localhost:7217"
));

builder.Services.AddScoped<INounService, NounService>();
builder.Services.AddScoped<IVerbService, VerbService>();
builder.Services.AddScoped<ISentenceService, SentenceService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

await builder.Build().RunAsync();

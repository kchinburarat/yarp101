using Gate.Filters;
var builder = WebApplication.CreateBuilder(args);

var isTye = Environment.GetEnvironmentVariable("TyeStack")?.Equals("true") ?? false;
builder.Configuration.AddYamlFile("Routing.yml");
var proxyBuilder = builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
if (isTye) proxyBuilder.AddConfigFilter<TyeFilters>();

var app = builder.Build();
app.MapReverseProxy();

app.Run();

using ApplicationUtilities.Configuration;
using ApplicationUtilities.Services;
using SampleWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddBitwardenSecretManagerConfiguration();

//if you continue to use the Options pattern, you may register other strongly-typed configurations here
builder.Services.Configure<MyOtherConfiguration>(builder.Configuration.GetSection(nameof(MyOtherConfiguration)));
builder.Services.Configure<BitwardenSecretsConfiguration>(builder.Configuration.GetSection(nameof(BitwardenSecretsConfiguration)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<ISecretManager, SecretManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints((endpoints) =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllers();
});

app.Run();
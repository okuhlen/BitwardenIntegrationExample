using ApplicationUtilities.Services;
using SampleWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddBitwardenSecretManagerConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
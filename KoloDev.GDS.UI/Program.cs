using KoloDev.GDS.UI.Configurators.Program;

var builder = WebApplication.CreateBuilder(args);

builder.AddKoloDevBaseServices();

var app = builder.Build();
app.ConfigureKoloDevBaseApp();
// Run app
app.Run();

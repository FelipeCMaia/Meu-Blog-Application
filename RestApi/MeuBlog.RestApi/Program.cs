using MeuBlog.RestApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
var env = builder.Environment;

app.UseApiConfiguration(env);
app.UseSwaggerConfig();

app.MapControllers();
app.Run();
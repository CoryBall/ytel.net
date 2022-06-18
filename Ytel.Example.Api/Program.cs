using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Ytel.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
})
    .AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ytelConfig = builder.Configuration.GetSection("Ytel").Get<YtelClientConfiguration>();
builder.Services.AddYtel(options =>
{
    options.ApiToken = ytelConfig.ApiToken;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Pokedex.API.Infrastruture.Http;
using Pokedex.API.Infrastruture.Interface;
using Pokedex.API.Infrastruture.Mapper;
using Pokedex.API.Infrastruture.Pokedex.API.Infrastruture;
using Pokedex.API.Service;
using Pokedex.API.Service.Interface;
using Pokedex.API.Service.Pokedex.API.Service;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serviços da APP
builder.Services.AddScoped<IDatabase, Database>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
//----------------------------------------------------------------------
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
//----------------------------------------------------------------------
builder.Services.AddScoped<ICaptureService, CaptureService>();
builder.Services.AddScoped<IPokemonMasterService, PokemonMasterService>();
builder.Services.AddScoped<IPokemonService, PokemonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Okr API");
    c.DocExpansion(DocExpansion.None);
    //c.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
    //{
    //    ["activated"] = false
    //};
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
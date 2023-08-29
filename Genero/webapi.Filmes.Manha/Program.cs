using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

//Adiciona o servi�o de controller 
builder.Services.AddControllers();

//Adiciona o servi�o de Swagger a cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informa��es sobre a API no swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Manh�",
        Description = "API para gerenciamento de filmes - introdu��o da sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Meu github",
            Url = new Uri("https://github.com/merbach020202/API_Professores")
        },
    });

    // Configura o swagger para gerar o arquivo xml gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//Come�a a configura��o do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configura��o do swagger

//Adiciona mapeamento dos controlers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

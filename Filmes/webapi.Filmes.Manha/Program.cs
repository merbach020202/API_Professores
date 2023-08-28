using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

//Adiciona o serviço de controller 
builder.Services.AddControllers();

//Adiciona o serviço de Swagger a coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre a API no swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Manhã",
        Description = "API para gerenciamento de filmes - introdução da sprint 2 - Backend API",
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

//Começa a configuração do swagger
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
//Finaliza a configuração do swagger

//Adiciona mapeamento dos controlers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

//Adiciona o servi�o de controller 
builder.Services.AddControllers();

//Adiciona servi�o de Jwt Bearer (forma de autentica��o)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valiad quem est� solicitando
        ValidateIssuer = true,

        //valida quem est[a recebendo
        ValidateAudience = true,

        //Define se o tempo de expira��o ser� validado
        ValidateLifetime = true,

        //Forma de criptografia que valida a chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //Nome do issuer (de onde est� vindo)
        ValidIssuer = "webapi.Filmes.Manha",

        //nome do audience (para onde est� indo)
        ValidAudience = "webapi.Filmes.Manha"
    };
});















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

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });


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

//Adiciona autentica��o
app.UseAuthentication();

//Adiciona autoriza��o
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();

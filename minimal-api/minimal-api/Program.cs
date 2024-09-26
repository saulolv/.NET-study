var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet( "/", () => "Hello World!");
app.MapPost("/login", (LoginDto loginDto) =>
{
    if (loginDto.Email == "adm@teste.com" && loginDto.Senha == "12345")
        return Results.Ok("Login com sucesso0");
    else return Results.Unauthorized();
});



app.Run();

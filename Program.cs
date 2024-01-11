using portfolio_api.Helpers;
using portfolio_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddScoped<IProfileService, ProfileService>();

//Http Clients
builder.Services.AddHttpClient<IProfileService, ProfileService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl:Profile"]);
});

// Helpers
builder.Services.AddScoped<IMarkdownFileProcesser, MarkdownFileProcesser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

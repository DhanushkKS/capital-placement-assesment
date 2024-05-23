using Assessment.Application.Repositories;
using Assessment.Infrastructure;
using Assessment.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mongodb configuration
builder.Services.Configure<DataBaseSettings>(
    builder.Configuration.GetSection("QuestionDataBase"));
builder.Services.AddSingleton<QDbContext>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddMediatR(
    m=>m.RegisterServicesFromAssemblies(typeof(IQuestionRepository).Assembly)
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
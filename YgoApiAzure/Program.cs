
using YgoData.DataCommand;
using YgoData.DataQuery;
using YgoData.DataQuery.Interface;
using YgoModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IDataCommand, DataCommand>();
builder.Services.AddScoped<IDataQuery<ExpansionDto>, ExpansionQuery>();
builder.Services.AddScoped<IDataQuery<RarityDto>, RarityQuery>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

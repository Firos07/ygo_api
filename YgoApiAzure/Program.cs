using YgoData.Interface;
using YgoData.YgoDataCommand;
using YgoData.YgoQuery;
using YgoLogic;
using YgoLogic.GetData;
using YgoLogic.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICardLogic, CardLogic>();
builder.Services.AddScoped<IYgoDataCommand, DataCardCommand>();
builder.Services.AddScoped<IDataCardGetList, DataCardGetList>();
builder.Services.AddScoped<IDataCardQuery, DataCardQuery>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

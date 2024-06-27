
using YgoData.DataCommand;
using YgoData.DataCommand.Interface;
using YgoData.DataQuery;
using YgoData.DataQuery.Interface;
using YgoModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICardInCollectionCommand, CardInCollectionCommand>();
builder.Services.AddScoped<ICollectionCommand, CollectionCommand>();
builder.Services.AddScoped<IDataCommand, DataCommand>();
builder.Services.AddScoped<IUserCommand, UserCommand>();

builder.Services.AddScoped<ICardQuery, CardQuery>();
builder.Services.AddScoped<IExpansionQuery, ExpansionQuery>();
builder.Services.AddScoped<IRarityQuery, RarityQuery>();
builder.Services.AddScoped<IUserQuery, UserQuery>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
    {
        ["activated"] = false
    };
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

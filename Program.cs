using Microsoft.EntityFrameworkCore;
using RestApiApp.Services;

var builder = WebApplication.CreateBuilder(args);
// db connection string defined in appsetting.json
var dbConnection = builder.Configuration.GetConnectionString("PGDBConn");
// resolve wirh IoC depenedence of class (repository) that use AppDBContext
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(dbConnection));

// every http request repository is istantiated by this macht rule
builder.Services.AddScoped<IMessagesRepository, MessagesRepository>();
builder.Services.AddScoped<IPrioritiesRepository, PrioritiesRepository>();

// scan attributes, class names to use as controller
builder.Services.AddControllers();

var app = builder.Build();

// direct route resolver
app.MapGet("/", () => "Rest api app 0.0.1");

// routes are setted in controllers
app.MapControllers();

app.Run();

using SampleApi.Utils.RedditApiClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRedditClient>(x => new RedditClient(builder.Configuration.GetConnectionString("RedditUsername"), builder.Configuration.GetConnectionString("RedditPassword"),
    builder.Configuration.GetConnectionString("RedditAppClientId"), builder.Configuration.GetConnectionString("RedditAppClientSecret"), builder.Configuration.GetConnectionString("SubredditName")));
builder.Services.AddMemoryCache();
builder.Services.AddLogging();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

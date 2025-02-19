using learn_worker;
using learn_worker.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<JokeService>();
builder.Services.AddHostedService<JokeWorkerService>();
builder.Services.ConfigureServices(builder.Configuration);

var host = builder.Build();
host.Run();

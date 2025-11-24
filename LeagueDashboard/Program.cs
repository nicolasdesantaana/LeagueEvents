using Aplication.Interfaces;
using Aplication.Services;
using Infraestructure;
using LeagueDashboard.Components;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

//DB CONTEXT
builder.Services.AddDbContext<LeagueContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//SERVICIES
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<MatchEventPublisher>();

// RabbitMQ / MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MatchEventConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("event-listener", e =>
        {
            cfg.Host(builder.Configuration["RabbitMQ:Host"]);
            e.ConfigureConsumer<MatchEventConsumer>(context);
        });
    });
});
builder.Services.AddMassTransitHostedService();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

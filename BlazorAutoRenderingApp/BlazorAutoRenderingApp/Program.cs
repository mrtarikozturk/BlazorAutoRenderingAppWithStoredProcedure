using BlazorAutoRenderingApp.Client.Pages;
using BlazorAutoRenderingApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorAutoRenderingApp.Data;
using BlazorAutoRenderingApp.DAL;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContextFactory<BlazorAutoRenderingAppContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorAutoRenderingAppContext") ?? throw new InvalidOperationException("Connection string 'BlazorAutoRenderingAppContext' not found.")));

//builder.Services.AddQuickGridEntityFrameworkAdapter();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddSingleton<Student_DAL>();

builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(BlazorAutoRenderingApp.Client._Imports).Assembly);

app.Run();

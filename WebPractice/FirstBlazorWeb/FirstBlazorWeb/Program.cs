global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Web;
global using FirstBlazorWeb.Data;
global using FirstBlazorWeb.Models;
using Blazored.SessionStorage;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddDbContext<EXLogContext>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IExerciselogService, ExerciselogService>();
builder.Services.AddScoped<IHealthchartService, HealthchartService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

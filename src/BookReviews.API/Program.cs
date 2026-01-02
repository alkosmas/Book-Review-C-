using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using BookReviews.Infrastructure.Persistence;
using BookReviews.Infrastructure.Identity;
using BookReviews.Application.Registration;
using BookReviews.Infrastructure.Registration;
using BookReviews.Application.Common.Interfaces;
using BookReviews.API.Services;           
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
//Controllers 
builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();

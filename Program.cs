using OpenDataApi.Domain.Models;
using OpenDataApi.Domain.Interfaces;
using OpenDataApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IHttpPhotoList, PhotoHttpList>();
builder.Services.AddHttpClient<IHttpAlbumList, AlbumHttpList>();
builder.Services.AddScoped<IPhotoAlbumList, PhotoAlbumList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

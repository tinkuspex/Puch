using Adapter.Alumno;
using AutoMapper;
using AutoMapper.Data.Configuration.Conventions;
using AutoMapper.Data.Mappers;
using Configuration;
using PruebaApi.Service;
using Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
//using IHost host = Host.CreateDefaultBuilder(args).Build();
//IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
//builder.Services.Configure<AppSettings>(config);
builder.Services.Configure<Configuration.Polly>(builder.Configuration.GetSection("Polly"));
builder.Services.Configure<Configuration.ConnectionString>(builder.Configuration.GetSection("ConnectionString"));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMyDependencyGroup();
Mapper.Initialize(cfg =>
{
    cfg.Mappers.Insert(0, new DataReaderMapper());
    _ = cfg.AddMemberConfiguration().AddMember<DataRecordMemberConfiguration>();
    _ = cfg.CreateMap<IDataRecord, AlumnoList>();
    _ = cfg.CreateMap<IDataReader, AlumnoList>();
    _ = cfg.CreateMap<IDataRecord, AlumnoRequest>();
    _ = cfg.CreateMap<IDataReader, AlumnoRequest>();

});
builder.Services.AddCustomAutomapper();
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

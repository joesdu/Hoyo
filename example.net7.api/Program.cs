using example.net7.api;
using Hoyo.AutoDependencyInjectionModule.Modules;
using Hoyo.WebCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(c =>
{
    _ = c.Filters.Add<ActionExecuteFilter>();
    _ = c.Filters.Add<ExceptionFilter>();
}).AddJsonOptions(c =>
{
    c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.TimeOnlyJsonConverter());
    c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateOnlyJsonConverter());
    c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.TimeOnlyNullJsonConverter());
    c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateOnlyNullJsonConverter());
    c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeConverter());
    c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

// �Զ�ע�����ģ��
builder.Services.AddApplication<AppWebModule>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) _ = app.UseDeveloperExceptionPage();

app.UseHoyoResponseTime();
app.UseAuthorization();

app.MapControllers();

// ����Զ���ע���һЩ�м��.
app.InitializeApplication();

app.Run();

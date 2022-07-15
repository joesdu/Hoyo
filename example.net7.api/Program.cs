using example.net7.api;
using Hoyo.AutoDependencyInjectionModule.Modules;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// ����֧��HTTP1/2/3
builder.WebHost.ConfigureKestrel((context, options) => options.ListenAnyIP(5273, listenOptions =>
{
    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
    _ = listenOptions.UseHttps();
}));

// Add services to the container.
// �Զ�ע�����ģ��
builder.Services.AddApplication<AppWebModule>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) _ = app.UseDeveloperExceptionPage();

// ����Զ���ע���һЩ�м��.
app.InitializeApplication();
app.MapControllers();

app.Run();

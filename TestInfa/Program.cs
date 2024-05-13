// See https://aka.ms/new-console-template for more information

using Infa.Helper.Redis;
using Infa.Interface.Helper.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestInfa;

Console.WriteLine("Hello, World!");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<IRedisConnectionHelp, RedisConnectionHelp>();
        services.AddTransient<RedisHelper>();
        services.AddTransient<TestService>();

    })
    .Build();
var service = host.Services.GetRequiredService<TestService>();
// service.ExcuteString();
// service.ExcuteListPush();
//  service.ListPopLeftTop1();
 service.ListPopLeftWithDataCount();
host.Run();    
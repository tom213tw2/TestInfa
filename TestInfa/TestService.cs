using Infa.Helper.Redis;
using Infa.Interface.Helper.Redis;
using Newtonsoft.Json;

namespace TestInfa;

public class TestService
{
   
    private readonly RedisHelper _redisHelper;

    public TestService(IRedisConnectionHelp redisConnectionHelp)
    {
        _redisHelper = new RedisHelper(redisConnectionHelp, 4);
    }
    public void ExcuteString()
    {
        _redisHelper.StringSet("TestString:Tom:F", new Demo
        {
            Sno = 1,
            Name = "Tom",
            DateTime = DateTime.Now
        },TimeSpan.FromMinutes(5));        
        Console.WriteLine(_redisHelper.StringGet("TestString:Tom:F"));
    }

    public void ExcuteListPush()
    {
        List<Demo> demos = new();
        for (int i = 0; i < 20; i++)
        {
            Demo demo = new()
            {
                Sno = i,
                Name = $"Tom_{i}",
                DateTime = DateTime.Now
            };
            _redisHelper.ListRightPush("TestList", demo);
        }

        var list = JsonConvert.SerializeObject(_redisHelper.ListRange<Demo>("TestList"));
        Console.WriteLine($"List Push : {list}");
    }

    public void ListPopLeftTop1()
    {
       
        var list = JsonConvert.SerializeObject(_redisHelper.ListRange<Demo>("TestList"));
        Console.WriteLine($"List All: {list}");
        Console.WriteLine("------------------------");
        list = JsonConvert.SerializeObject(_redisHelper.ListLeftPop<Demo>("TestList"));
        Console.WriteLine($"list : {list}");
        Console.WriteLine("------------------------");
        list = JsonConvert.SerializeObject(_redisHelper.ListRange<Demo>("TestList"));
        Console.WriteLine(list);
    }

    public void ListPopLeftWithDataCount()
    {
        var list = JsonConvert.SerializeObject(_redisHelper.ListRange<Demo>("TestList"));
        Console.WriteLine($"List All: {list}");
        Console.WriteLine("------------------------");
        list = JsonConvert.SerializeObject(_redisHelper.ListLeftPop<Demo>("TestList",5));
        Console.WriteLine($"list : {list}");
        Console.WriteLine("------------------------");
        list = JsonConvert.SerializeObject(_redisHelper.ListRange<Demo>("TestList"));
        Console.WriteLine(list);
    }
}

public class Demo
{
    public int Sno { get; set; }

    public string Name { get; set; }

    public DateTime DateTime { get; set; }
}
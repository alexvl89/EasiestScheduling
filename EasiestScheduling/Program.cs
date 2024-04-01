using Coravel;
using EasiestScheduling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddScheduler();
builder.Services.AddTransient<MyRepeatableTask>();

var app = builder.Build();

app.Services.UseScheduler(async scheduler =>
{
    //scheduler.Schedule(() => Console.WriteLine("This was scheduled"))
    //    .EverySeconds(2);

    scheduler.ScheduleAsync(async () =>
    {
        await Task.Delay(20);

        await Console.Out.WriteLineAsync("This is scheduled");

    }).EverySeconds(2);

    //scheduler.Schedule<MyRepeatableTask>()
    //    .EverySeconds(5);

    scheduler.ScheduleWithParams<MyRepeatableTask>("localhost:5001")
        .EverySeconds(5);

});


app.Run();
var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/get", async (CancellationToken cancellationToken, HttpContext ctx) =>
{
        ctx.Response.Headers.Add("Content-Type", "text/event-stream");
        int i = 2; 
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(2000);
            var text = i + " seconds have passed";
            i = i+2;

            await ctx.Response.WriteAsync($"event: " + text + "\n");

        }   
});

app.Run();
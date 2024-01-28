var app= WebApplication.CreateBuilder(args).Build();

app.MapGet("/post", () =>
{
    string id = Guid.NewGuid().ToString();
    JobsManager.Add(id);
    return id;
});
app.MapGet("/check/{id}", (string id) =>
{
    return JobsManager.Check(id);
});

app.Run();
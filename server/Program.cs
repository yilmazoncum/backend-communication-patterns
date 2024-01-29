using Microsoft.AspNetCore.Mvc;

var app = WebApplication.CreateBuilder(args).Build();

app.MapGet("/post", () =>
{
    string id = Guid.NewGuid().ToString();
    JobsManager.Add(id);
    return id;
});

app.MapGet("/get/{id}", ([FromRoute] string id, CancellationToken cancellationToken) =>
{
    try
    {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromSeconds(30));

        var value = JobsManager.GetAsync(cancellationToken, id);

        if (value != null)
        {
            return Results.Ok(value);
        }

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
        return Results.NoContent();
    }
});

app.Run();
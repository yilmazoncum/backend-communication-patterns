//Server side

var app = WebApplication.CreateBuilder(args).Build();

var cities = new[]
{
    "New York", "Amsterdam", "Berlin","Moscow","Rome",
    "Istanbul","London","Paris","Tokyo","Madrid"
};

app.MapGet("/city", () => {
    
    //generate random number
    Random r = new Random();   
    int randomNumber = r.Next(0,10); 

    return cities[randomNumber];
});

app.Run();
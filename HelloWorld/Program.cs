using HelloWorld;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSingleton<A>();
//builder.Services.AddTransient<A>();
builder.Services.AddScoped<A>();
builder.Services.AddScoped<B>();
builder.Services.AddScoped<INotifica, NotificaWhatsApp>();
builder.Services.AddScoped<INotifica, NotificaSMS>();
builder.Services.AddScoped<INotifica, NotificaEMail>();
builder.Services.AddScoped<IClock, ClockPerTestAlMattino>();
builder.Services.AddScoped<ISaluto, SalutoSemplice>();

var app = builder.Build();

//var x = app.Environment.IsDevelopment();
//var y = app.Environment.IsProduction();
//app.Environment.IsEnvironment("MioAmbiente");


app.MapGet("/", (B b, ISaluto saluto) => {
    return saluto.Saluta("Mario") + " " + b.PrintB();
    //return b.PrintB(); 
});

app.Run();

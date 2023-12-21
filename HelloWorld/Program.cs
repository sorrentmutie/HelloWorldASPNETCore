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

//app.UseWelcomePage();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
} else
{
   // app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    var logger =
       context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Ciao sono nel secondo  logger");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    var logger =
       context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Ciao sono nel primo logger");
    await next.Invoke();
});


app.Use(async (context, next) =>
{
    if(context.Request.Path == "/categories")
    {
        await context.Response.WriteAsync("Non puoi accedere");
    } else
    {
        await next.Invoke();
    }
});

app.Map("/products", MyHandleMap1);
app.Map("/events",  (app) =>
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Events");
    });
});

void MyHandleMap1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Products");
    });
}

app.Run(async context =>
{
    // throw new Exception("Eccezione lanciata");
    await context.Response.WriteAsync("Hello World!");
});

//app.MapGet("/", (B b, ISaluto saluto) => {
//    return saluto.Saluta("Mario") + " " + b.PrintB();
//    //return b.PrintB(); 
//});

app.Run();

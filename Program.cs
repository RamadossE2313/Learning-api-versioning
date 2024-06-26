var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiVersioning( v =>
{
    // when version not provided, we will assume version
    // (set default version)
    v.AssumeDefaultVersionWhenUnspecified = true;
    v.DefaultApiVersion = new ApiVersion(1, 0);

    // it will added all the request,
    // api supported version and api deprecated version
    v.ReportApiVersions = true;

    v.ApiVersionReader = ApiVersionReader.Combine(
        // it will support version based on query string
        new QueryStringApiVersionReader("api-version"),
        // it will support version based on header
        new HeaderApiVersionReader("X-Version"),
        // it will support version based on media type
        new MediaTypeApiVersionReader("ver"));
})
.AddMvc()
.AddApiExplorer(options =>
{
    // 'v' is major version remaining all are in minor versions
    options.GroupNameFormat = "'v'vvv";
    //it's used in uri segements
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

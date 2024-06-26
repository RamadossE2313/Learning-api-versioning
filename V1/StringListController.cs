using Microsoft.AspNetCore.Mvc;

namespace LearningRestApiVersioning.V1
{
    // query string, header and mediatype format we can use this way

    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class StringListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetWeathers()
        {
            return WeatherData.Summaries.Where(weather => weather.StartsWith("B"));
        }
    }
}

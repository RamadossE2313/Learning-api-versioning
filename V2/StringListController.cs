using Microsoft.AspNetCore.Mvc;

namespace LearningRestApiVersioning.V2
{
    // query string, header and mediatype format we can use this way
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetWeathers()
        {
            return WeatherData.Summaries.Where(weather => weather.StartsWith("C"));
        }
    }
}

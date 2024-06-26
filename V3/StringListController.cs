using Microsoft.AspNetCore.Mvc;

namespace LearningRestApiVersioning.V3
{
    // URI based api version and it's easy to use it.
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("3.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetWeathers()
        {
            return WeatherData.Summaries.Where(weather => weather.StartsWith("H"));
        }
    }
}

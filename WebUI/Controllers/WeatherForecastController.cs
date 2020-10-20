using System.Collections.Generic;
using System.Threading.Tasks;
using Application.WeatherForecast.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var user = HttpContext.User;
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
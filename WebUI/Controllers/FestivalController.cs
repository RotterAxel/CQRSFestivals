using System.Threading.Tasks;
using Application.Festivals.Commands.CreateFestival;
using Application.Festivals.Commands.UpdateFestival;
using Application.Festivals.Queries.GetFestivalDetail;
using Application.Festivals.Queries.GetFestivals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class FestivalController : ApiController
    {
        [HttpGet(Name = "GetFestivals")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FestivalsVm>> GetFestivals()
        {
            return await Mediator.Send(new GetFestivalsQuery());
        }
        
        [Produces("application/json")]
        [HttpGet("{festivalId}", Name = "GetFestival")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FestivalDetailVm>> GetFestival(int festivalId)
        //[FromHeader(Name = "Accept")] string mediaType)
        {
            //You can do a Accept-Header check if you want to enforce the Media Type
            // if (!MediaTypeHeaderValue.TryParse(mediaType,
            //     out _))
            // {
            //     return BadRequest();
            // }

            return Ok(await Mediator.Send(new GetFestivalDetailQuery {Id = festivalId}));
        }
        
        [HttpPost(Name = "CreateFestival")]
        [Produces("application/json",
            "application/vnd.mimo.festival.full+json")]
        [Consumes("application/json",
            "application/vnd.mimo.festivalforcreation+json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateFestivalCommand createFestivalCommand)
        {
            int createdFestivalId = await Mediator.Send(createFestivalCommand);

            return CreatedAtRoute("GetFestival",
                new { festivalId = createdFestivalId },
                null);
        }

        [HttpPatch("{festivalId}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PartiallyUpdateFestival(int festivalId,
            UpdateFestivalCommand updateFestivalCommand)
        {
            if (festivalId != updateFestivalCommand.FestivalId)
            {
                return BadRequest();
            }

            await Mediator.Send(updateFestivalCommand);
            
            return NoContent();
        }
    }
}
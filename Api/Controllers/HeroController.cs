using System.Threading.Tasks;
using Api.Dto;
using Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService heroService;

        public HeroController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        [HttpPost]
        [Route("HeroAPI")]
        public async Task<IActionResult> Hero([FromBody] HeroDto heroDto)
        {
            if (string.IsNullOrEmpty(heroDto.Name) || string.IsNullOrEmpty(heroDto.Power))
                return BadRequest("Invalid hero");

            return Ok(await heroService.InsertHero(new Hero(heroDto.Name, heroDto.Power)));
        }
    }
}
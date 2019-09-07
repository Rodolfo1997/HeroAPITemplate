using System;
using System.Threading.Tasks;
using Api.Dto;
using AutoMapper;
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
        private readonly IMapper mapper;

        public HeroController(IHeroService heroService, IMapper mapper)
        {
            this.heroService = heroService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("getAllHeroes")]
        public async Task<IActionResult> GetHeroes()
        {
            return Ok(await heroService.GetHeroes());
        }

        [HttpGet]
        [Route("getHero")]
        public async Task<IActionResult> GetHero(string heroId)
        {
            if (string.IsNullOrEmpty(heroId))
            {
                return BadRequest("HeroId is invalid");
            }

            return Ok(await heroService.GetHero(Guid.Parse(heroId)));
        }

        [HttpPost]
        [Route("insertHero")]
        public async Task<IActionResult> InsertHero([FromBody] HeroDto heroDto)
        {
            if (string.IsNullOrEmpty(heroDto.Name) || string.IsNullOrEmpty(heroDto.Power))
            {
                return BadRequest("Hero Name or Hero Power are invalid.");
            }

            var hero = mapper.Map<Hero>(heroDto);

            return Ok(await heroService.InsertHero(hero));
        }

        [HttpPut]
        [Route("updateHero")]
        public async Task<IActionResult> UpdateHero([FromBody] HeroDto heroDto)
        {
            if (string.IsNullOrEmpty(heroDto.HeroId.ToString()))
            {
                return BadRequest("Hero Id is invalid.");
            }

            if (string.IsNullOrEmpty(heroDto.Name) || string.IsNullOrEmpty(heroDto.Power))
            {
                return BadRequest("Hero Name or Hero Power are invalid.");
            }

            return Ok(await heroService.UpdateHero(new Hero(Guid.Parse(heroDto.HeroId), heroDto.Name, heroDto.Power)));
        }

        [HttpDelete]
        [Route("deleteHero")]
        public async Task<IActionResult> Delete(string heroId)
        {
            if (string.IsNullOrEmpty(heroId))
            {
                return BadRequest("HeroId is invalid");
            }

            return Ok(await heroService.DeleteHero(Guid.Parse(heroId)));
        }
    }
}
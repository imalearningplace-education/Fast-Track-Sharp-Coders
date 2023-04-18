using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Domain;
using SuperHeroApi.Domain.Model;

namespace SuperHeroApi.Controllers;

[Route("heroes")]
public class HeroController : ControllerBase {

    private static IEnumerable<Hero> _heroes = new List<Hero> {
        new Hero { Id = 1, Name = "Superman", RealName = "Clark Kent", Age = 35, IsRetired = false },
        new Hero { Id = 2, Name = "Batman", RealName = "Bruce Wayne", Age = 40, IsRetired = false },
        new Hero { Id = 3, Name = "Wonder Woman", RealName = "Diana Prince", Age = 28, IsRetired = false },
        new Hero { Id = 4, Name = "Spider-Man", RealName = "Peter Parker", Age = 25, IsRetired = false },
        new Hero { Id = 5, Name = "Iron Man", RealName = "Tony Stark", Age = 45, IsRetired = false },
        new Hero { Id = 6, Name = "Captain America", RealName = "Steve Rogers", Age = 100, IsRetired = true },
        new Hero { Id = 7, Name = "Black Widow", RealName = "Natasha Romanoff", Age = 38, IsRetired = false },
        new Hero { Id = 8, Name = "Thor", RealName = "Thor Odinson", Age = 1500, IsRetired = false },
        new Hero { Id = 9, Name = "The Flash", RealName = "Barry Allen", Age = 30, IsRetired = false },
        new Hero { Id = 10, Name = "Aquaman", RealName = "Arthur Curry", Age = 35, IsRetired = false }
    };

    private HeroContext _heroContext;

    public HeroController(HeroContext heroContext) {
        _heroContext = heroContext;
    }

    [HttpGet] // .../heroes
    public ActionResult<IEnumerable<Hero>> GetAllHeroes(
        [FromQuery] int p = 1, // 3
        [FromQuery] int q = 2 // 40
    ) {
        int offset = (p - 1) * q; // 
        return Ok(_heroes.Skip(offset).Take(q));
    }

    [HttpGet] // .../heroes/1
    [Route("{id}")]
    public ActionResult<Hero?> GetHeroById(int id) {
        var hero = _heroes.FirstOrDefault(h => h.Id == id);

        if (hero == null)
            return NotFound();

        return Ok(hero);
    }

    [HttpPost]
    public ActionResult<Hero> RegisterHero([FromBody] Hero hero) {
        _heroContext.Heroes.Add(hero);
        _heroContext.SaveChanges();
        return CreatedAtAction(nameof(GetHeroById) , new { Id = hero.Id }, hero);
    }

}

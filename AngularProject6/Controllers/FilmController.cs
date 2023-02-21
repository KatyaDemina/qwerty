using AngularProject6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProject6.Controllers
{
    [Route("api/[film]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        AppContext _db;
        public FilmController(AppContext cntx)
        {
            _db = cntx;
            if (!_db.Films.Any())
            { _db.Films.Add(new Film { Title = "Джанго освобожденный", Year = 2012, Genre = "Вестерн" });
                _db.Films.Add(new Film { Title = "The Menu", Year = 2022, Genre = "Триллер" });
                _db.Films.Add(new Film { Title = "Бойцовский клуб", Year = 1999, Genre = "Боевик" });
                _db.Films.Add(new Film { Title = "Семь", Year = 1995, Genre = "Детектив" });
              _db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _db.Films.ToList();
        }
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            Film film = _db.Films.FirstOrDefault(f => f.Id == id);
            return film;
        }
        [HttpPost]
        public IActionResult Post(Film film)
        {
            if (ModelState.IsValid)
            {
                _db.Films.Add(film);
                _db.SaveChanges();
                return Ok(film);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put(Film film)
        {
            if (ModelState.IsValid)
            {
                _db.Update(film);
                _db.SaveChanges();
                return Ok(film);
            }
        }
            
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Film film = _db.Films.FirstOrDefault(f => f.Id == id);
            if (film != null)
            {
                _db.Films.Remove(film);
                _db.SaveChanges();
            }
            return Ok(film);
        }
    }
}

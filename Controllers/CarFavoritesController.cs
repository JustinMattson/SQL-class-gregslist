using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using fullstack_gregslist.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CarFavoritesController : ControllerBase
    {
        private readonly CarFavoritesService _cfs;

        public CarFavoritesController(CarFavoritesService cfs)
        {
            _cfs = cfs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ViewModelCarFavorite>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cfs.Get(userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<DTOCarFavorite> Create([FromBody] DTOCarFavorite fav)
        {
            try
            {
                fav.User = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cfs.Create(fav));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult<DTOCarFavorite> Delete(int Id)
        {
            try
            {
                string user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cfs.Delete(user, Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
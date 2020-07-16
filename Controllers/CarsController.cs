using System;
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
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;

        public CarsController(CarsService cs)
        {
            _cs = cs;
        }
        // NOTE path is https://localhost:5001/api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            try
            {
                return Ok(_cs.GetAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //NOTE path does not follow standards https://localhost:5001/api/cars/user
        [HttpGet("user")]
        [Authorize]
        public ActionResult<IEnumerable<Car>> GetCarsByUser()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.GetByUserId(userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // NOTE path is https://localhost:5001/api/cars/id
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            try
            {
                return Ok(_cs.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                newCar.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.Create(newCar));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Car> Edit(int id, [FromBody] Car carToUpdate)
        {
            try
            {
                carToUpdate.Id = id;
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.Edit(carToUpdate, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }



        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.Delete(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Touriss.Dtos;
using Touriss.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Touriss.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly TourissContext _context;

        public CityController(TourissContext context) //Context nay duong truyen o file StartUp
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityToReturnDto>>> GetCities()
        {
            var city = await _context.Cities.ToListAsync();
            return city.Select(city => new CityToReturnDto
            {
                Id = city.Id,
                Name = city.Name,
                Photos = city.Photos.ToString()
            }).ToList();
        }
    }
}

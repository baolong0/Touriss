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
    public class HotelController : ControllerBase
    {
        private readonly TourissContext _context;

        public HotelController(TourissContext context) //Context nay duong truyen o file StartUp
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelToReturnDto>>> GetHotels()
        {
            var hotels = await _context.Hotels
                                .Include(h => h.Types)
                                .Include(h => h.Address)
                                .ToListAsync();
            var types = await _context.Types
                                .ToListAsync();
            return hotels.Select(hotels => new HotelToReturnDto
            {
                Id = hotels.Id,
                Name = hotels.Name,
                Address = hotels.Address.City.ToString(),
                Photos = hotels.Photos.ToString(),
                Types = types.Where(x=> x.IdHotel==hotels.Id).Select(x => x.Price).ToString(),
            }).ToList();
        }
    }
}

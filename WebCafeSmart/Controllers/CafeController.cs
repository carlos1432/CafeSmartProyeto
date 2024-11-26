using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace WebCafeSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly CafeService _cafeService;

        public CafeController(CafeService cafeService)
        {
            _cafeService = cafeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var cafes = await _cafeService.GetAll();
            return Ok(cafes);  // Devolver los datos como JSON en la respuesta
        }
    }
}

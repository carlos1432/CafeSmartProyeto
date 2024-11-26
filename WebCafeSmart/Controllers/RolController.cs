using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace WebCafeSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService cafeService)
        {
            _rolService = cafeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolService.GetRoles();
            return Ok(roles);  // Devolver los datos como JSON en la respuesta
        }
    }
}

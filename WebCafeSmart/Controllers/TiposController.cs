using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace WebCafeSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly TiposService _tipoService;

        public TiposController(TiposService tipoService)
        {
            _tipoService = tipoService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _tipoService.GetTipos();
            return Ok(tipos);  // Devolver los datos como JSON en la respuesta
        }
    }
}


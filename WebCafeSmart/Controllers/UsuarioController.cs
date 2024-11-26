using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace WebCafeSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _usuarioService.GetUsuarios();
            return Ok(tipos);  // Devolver los datos como JSON en la respuesta
        }
    }
}

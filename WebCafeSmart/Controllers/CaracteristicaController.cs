using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCafeSmart.Services;

namespace WebCafeSmart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteristicaController : ControllerBase
    {
        private readonly CaracteristicaService _caracteristicaService;

        public CaracteristicaController(CaracteristicaService caracteristicaService)
        {
            _caracteristicaService = caracteristicaService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var caracteristicas = await _caracteristicaService.GetCaracteristicas();
            return Ok(caracteristicas);  // Devolver los datos como JSON en la respuesta
        }
    }
}

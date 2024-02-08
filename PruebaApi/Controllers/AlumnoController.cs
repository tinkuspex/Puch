using Adapter.Alumno;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services;
using Microsoft.Extensions.Configuration;
namespace PruebaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        private readonly ILogger<AlumnoController> _logger;
        private readonly IConfiguration _configuration;
        public AlumnoController(IAlumnoService alumnoService, ILogger<AlumnoController> logger, IConfiguration configuration)
        {
            _alumnoService = alumnoService;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpPost("SaveAlumnoAsync")]
        public async Task<IActionResult> SaveAlumnoAsync([FromBody, BindRequired] AlumnoList requests)
        {
            var data = await _alumnoService.SaveAlumnoAsync(requests);

            return StatusCode(200, data);
        }
        [HttpPost ("GetListaAlumnosAsync")]
        public async Task<IActionResult> GetListaAlumnosAsync([FromBody, BindRequired] AlumnoRequest requests)
        {
            var data = await _alumnoService.GetListaAlumnosAsync(requests);

            return StatusCode(200, data);
        }
    }
}

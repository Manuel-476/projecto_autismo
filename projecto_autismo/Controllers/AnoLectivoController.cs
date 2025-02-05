using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projecto_autismo.Application.Dto;
using projecto_autismo.Application.Services;

namespace projecto_autismo.Controllers
{
    [Route("api/AnoLectivo")]
    [ApiController]
    public class AnoLectivoController : ControllerBase
    {
        IAnoLectivo _anoLectivo;
        public AnoLectivoController(IAnoLectivo anoLectivo)
        {
            _anoLectivo = anoLectivo;
        }

        [HttpPost]
        public IActionResult SalvarAnoLectivo(AnoLectivoDto anoLectivo)
        {
            var result = _anoLectivo.SalvarAnoLectivo(anoLectivo);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAnos()
        {
            var result = _anoLectivo.ListarAnos();

            return Ok(result);
        }

        [HttpGet("{anoId}")]
        public IActionResult GetAnoPeloId(int anoId)
        {
            var result = _anoLectivo.ObterAnoLectivoPeloId(anoId);

            return Ok(result);
        }

        [HttpDelete("{anoId}")]
        public IActionResult DeleteAnoPeloId(int anoId)
        {
            var result = _anoLectivo.ApagarAnoLectivo(anoId);

            return Ok(result);
        }

        [HttpPut("{anoId}")]
        public IActionResult UpdatePeloId(int anoId, AnoLectivoDto anoLectivo)
        {
            var result = _anoLectivo.AlterarDadosAnoLectivo(anoId, anoLectivo);

            return Ok(result);
        }

        [HttpPost]
        [Route("trimestre")]
        public IActionResult SaveTrimestre(TrimestreDto trimestre)
        {
            var result = _anoLectivo.SalvarTrimestre(trimestre);

            return Ok(result);
        }

        [HttpGet]
        [Route("trimestre")]
        public IActionResult GetTrimestres()
        {

            var result = _anoLectivo.ListarTrimestres();

            return Ok(result);
        }

        [HttpGet]
        [Route("trimestre/{trimestreId}")]
        public IActionResult GetTrimestrePeloId(int trimestreId)
        {

            var result = _anoLectivo.ObterTrimestrePeloId(trimestreId);

            return Ok(result);
        }

        [HttpDelete]
        [Route("trimestre/{trimestreId}")]
        public IActionResult UpdateTrimestrePeloId(int trimestreId)
        {
            var result = _anoLectivo.ApagarTrimestre(trimestreId);

            return Ok(result);
        }

        [HttpPut]
        [Route("trimestre/{trimestreId}")]
        public IActionResult UpdateTrimestrePeloId(int trimestreId, TrimestreDto trimestre)
        {
            var result = _anoLectivo.AlterarDadosTrimestre(trimestreId, trimestre);

            return Ok(result);
        }
    }
}

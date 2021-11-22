using GravacaoLog.Aplicacao;
using GravacaoLog.Data.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GravacaoLog.Api.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class GravacaoLogController : ControllerBase
    {
        private readonly ILogAplicacao _logAplicacao;

        public GravacaoLogController(ILogAplicacao logAplicacao)
        {
            _logAplicacao = logAplicacao;
        }

        [HttpGet]
        [Route("buscarlogs")] 
        public async Task<IActionResult> BuscarLogs()
        {
            try
            {
                return Ok(await _logAplicacao.BuscarLogs());            
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("buscarlogs")]
        public async Task<IActionResult> BuscarLogs([FromBody] LogDTO log)
        {
            try
            {
                await _logAplicacao.CadastrarLog(log);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

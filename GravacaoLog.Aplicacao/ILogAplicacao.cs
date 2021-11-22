using GravacaoLog.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GravacaoLog.Aplicacao
{
    public interface ILogAplicacao
    {
        Task<IEnumerable<LogDTO>> BuscarLogs();
        Task<LogDTO> BuscarLog(string id);
        Task<IEnumerable<LogDTO>> BuscarLogDescricao(string descricao);
        Task CadastrarLog(LogDTO log);
        Task<bool> DeletaLog(string id);
    }
}

using GravacaoLog.Data.Entidade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GravacaoLog.Data.Repositorio
{
    public interface ILogRepositorio
    {
        Task<IEnumerable<Log>> BuscarLogs();
        Task<Log> BuscarLog(string id);
        Task<IEnumerable<Log>> BuscarLogDescricao(string descricao);
        Task CadastrarLog(Log log);
        Task<bool> DeletaLog(string id);
    }
}

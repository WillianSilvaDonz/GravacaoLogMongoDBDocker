using GravacaoLog.Data.Entidade;
using MongoDB.Driver;

namespace GravacaoLog.Data.Contexto
{
    public interface IGravacaoLogContexto
    {
        IMongoDatabase Database { get; set; }
        IMongoCollection<Log> Logs { get; set; }
    }
}

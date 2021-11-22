using GravacaoLog.Data.Entidade;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace GravacaoLog.Data.Contexto
{
    public class GravacaoLogContexto : IGravacaoLogContexto
    {
        public GravacaoLogContexto(IConfiguration configuration)
        {
            var cliente = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            Database = cliente.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);
        }

        public IMongoDatabase Database { get; set; }

        public IMongoCollection<Log> Logs { get; set; }
    }
}

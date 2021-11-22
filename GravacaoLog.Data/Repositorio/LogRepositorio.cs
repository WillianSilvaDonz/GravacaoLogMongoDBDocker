using GravacaoLog.Data.Contexto;
using GravacaoLog.Data.Entidade;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GravacaoLog.Data.Repositorio
{
    public class LogRepositorio : ILogRepositorio
    {
        private readonly IGravacaoLogContexto _context;
        public LogRepositorio(IConfiguration configuration, IGravacaoLogContexto context)
        {
            _context = context;
            _context.Logs = _context.Database.GetCollection<Log>(configuration.GetSection("DatabaseSettings:CollectionName").Value);
        }

        public async Task<Log> BuscarLog(string id)
        {
            return await _context.Logs.Find(l => l.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Log>> BuscarLogDescricao(string descricao)
        {
            FilterDefinition<Log> filter = Builders<Log>.Filter.ElemMatch(l => l.Texto, descricao);

            return await _context.Logs.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Log>> BuscarLogs()
        {
            return await _context.Logs.Find(l => true).ToListAsync();
        }

        public async Task CadastrarLog(Log log)
        {
            await _context.Logs.InsertOneAsync(log);
        }

        public async Task<bool> DeletaLog(string id)
        {
            FilterDefinition<Log> filter = Builders<Log>.Filter.Eq(l => l.Id, id);
            DeleteResult deleteResult = await _context.Logs.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}

using GravacaoLog.Data.DTO;
using GravacaoLog.Data.Entidade;
using GravacaoLog.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GravacaoLog.Aplicacao
{
    public class LogAplicacao : ILogAplicacao
    {
        private readonly ILogRepositorio _repositorio;

        public LogAplicacao(ILogRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<LogDTO> BuscarLog(string id)
        {
            var log = await _repositorio.BuscarLog(id);
            if (log == null)
                throw new KeyNotFoundException();

            return new LogDTO
            {
                Data = log.Data,
                Error = log.Error,
                Recebeu = (log.Recebeu == null)? null : new RecebeuDTO { 
                    Id = log.Recebeu.Id,
                    Data = log.Recebeu.Data,
                    Descricao = log.Recebeu.Descricao
                },
                Texto = log.Texto,
                Id = log.Id
            };
        }

        public async Task<IEnumerable<LogDTO>> BuscarLogDescricao(string descricao)
        {
            var logs = await _repositorio.BuscarLogDescricao(descricao);
            if (logs == null)
                throw new KeyNotFoundException();

            List<LogDTO> logsDto = new List<LogDTO>();
            foreach(var log in logs)
            {
                logsDto.Add(new LogDTO
                {
                    Data = log.Data,
                    Error = log.Error,
                    Recebeu = (log.Recebeu == null) ? null : new RecebeuDTO
                    {
                        Id = log.Recebeu.Id,
                        Data = log.Recebeu.Data,
                        Descricao = log.Recebeu.Descricao
                    },
                    Texto = log.Texto,
                    Id = log.Id
                });
            }

            return logsDto;
        }

        public async Task<IEnumerable<LogDTO>> BuscarLogs()
        {
            var logs = await _repositorio.BuscarLogs();
            if (logs == null)
                throw new KeyNotFoundException();

            List<LogDTO> logsDto = new List<LogDTO>();
            foreach (var log in logs)
            {
                logsDto.Add(new LogDTO
                {
                    Data = log.Data,
                    Error = log.Error,
                    Recebeu = (log.Recebeu == null) ? null : new RecebeuDTO
                    {
                        Id = log.Recebeu.Id,
                        Data = log.Recebeu.Data,
                        Descricao = log.Recebeu.Descricao
                    },
                    Texto = log.Texto,
                    Id = log.Id
                });
            }

            return logsDto;
        }

        public async Task CadastrarLog(LogDTO log)
        {
            await _repositorio.CadastrarLog(new Log
            {
                Data = DateTime.Now,
                Error = log.Error,
                Recebeu = ((log.Recebeu == null) ? null : new Recebeu { 
                    Data =  DateTime.Now,
                    Descricao = log.Recebeu.Descricao
                }),
                Texto = log.Texto
            });
        }

        public Task<bool> DeletaLog(string id)
        {
            return _repositorio.DeletaLog(id);
        }
    }
}

using System;

namespace GravacaoLog.Data.DTO
{
    public class LogDTO
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public RecebeuDTO Recebeu { get; set; }
        public string Texto { get; set; }
        public bool Error { get; set; }
    }
}

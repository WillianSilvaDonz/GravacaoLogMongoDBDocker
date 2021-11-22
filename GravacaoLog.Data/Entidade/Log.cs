using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GravacaoLog.Data.Entidade
{
    public class Log
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public Recebeu Recebeu { get; set; }
        public string Texto { get; set; }
        public bool Error { get; set; }
    }
}

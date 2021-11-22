using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GravacaoLog.Data.Entidade
{
    public class Recebeu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}

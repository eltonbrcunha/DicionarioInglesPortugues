using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace EltonTradutor.Models
{
    public class Palavra
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Termo { get; set; }
        public string Pronuncia { get; set; }
        public string Traducao { get; set; }
        public string Tags { get; set; }
        
    }
}

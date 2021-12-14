using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Project
{
    [BsonIgnoreExtraElements]
    public class Radreply_dim
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }
        
        [BsonElement("username")]
        public string userName { get; set; }

        [BsonElement("value")]
        public string value { get; set; }
        
    }
   
}

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Project
{
    [BsonIgnoreExtraElements]
    public class DeviceOwnership_dim
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }

         [BsonElement("activeUntil")]
        public DateTime activeUntil { get; set; }

        [BsonElement("dateRegistered")]
        public DateTime dateRegistered { get; set; }

        [BsonElement("state")]
        public int state { get; set; }

        [BsonElement("deviceName")]
        public string deviceName { get; set; }

        [BsonElement("MAC")]
        public string MAC { get; set; }

        [BsonElement("vlan")]
        public string vlan { get; set; }
        
    }
   
}

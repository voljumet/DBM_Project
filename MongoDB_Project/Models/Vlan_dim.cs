using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Project
{
    [BsonIgnoreExtraElements]
    public class Vlan_dim
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

         [BsonElement("VlanName")]
        public string VlanName { get; set; }

        [BsonElement("VlanAlias")]
        public string VlanAlias { get; set; }

        [BsonElement("SSID")]
        public string SSID { get; set; }

        [BsonElement("AccessibleByUser")]
        public string AccessibleByUser { get; set; }
        

    }

 
   
}

using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Project
{
    [BsonIgnoreExtraElements]
    public class ApplicationUser_dim
    {
        [BsonElement("Id")]
        public ObjectId Id { get; set; }

         [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("groupMembership")]
        public int groupMembership { get; set; }
        
    }
   
}

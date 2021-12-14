using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Project
{
    [BsonIgnoreExtraElements]
    public class Fact_table
    {
        public Radreply_dim radreply_Dim { get; set; }

        public Radacct_dim radacct_dim { get; set; }

        public ApplicationUser_dim applicationUser_dim { get; set; }

        public DeviceOwnership_dim deviceOwnership_dim { get; set; }
        
    }
   
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//using MongoDB.Entities;
using System.Collections.Generic;

namespace NationalParks.Models
{
    public class Park
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("countryCode")]
        public string CountryCode { get; set; }

        [BsonElement("countryName")]
        public string CountryName { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("toponymName")]
        public string ToponymName { get; set; }

        [BsonElement("coordinates")]
        public List<double> Location { get; set; }

    }
}
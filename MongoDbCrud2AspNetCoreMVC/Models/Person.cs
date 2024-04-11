using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbCrud2AspNetCoreMVC.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("PersonName")]
        public string PersonName { get; set; }

        [BsonElement("PersonAge")]
        public int PersonAge { get; set; }

        [BsonElement("HomeTown")]
        public string HomeTown { get; set; }
    }
}

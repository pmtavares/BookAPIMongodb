using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApiMongo.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string BookName { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }


        [BsonElement("Author")]
        public Author Author { get; set; }

        public int AuthorId { get; set; }

        [BsonElement("Authors")]
        public List<string> Authors { get; set; }



    }

    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string AuthorName { get; set; }

        [BsonElement("Surname")]
        [JsonProperty("Surname")]
        public string AuthorSurname { get; set; }

        [BsonElement("Country")]
        [JsonProperty("Country")]
        public string Country { get; set; }

       
    }
}

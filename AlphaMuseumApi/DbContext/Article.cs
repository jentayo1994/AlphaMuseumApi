using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlphaMuseumApi.DbContext
{
    public class Article
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("imgSrc")]
        public string ImgSrc { get; set; }
        [BsonElement("imgAuthorSrc")]
        public string ImgAuthorSrc { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("date")]
        public string Date { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }

    }
}

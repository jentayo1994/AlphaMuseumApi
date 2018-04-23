namespace AlphaMuseumApi.DbContext
{
    public class MongoDbOptions
    {
        public string ConnectionString;
        public MongoDbOptions()
        {
            ConnectionString = "mongodb://localhost:27017";
        }
    }
}
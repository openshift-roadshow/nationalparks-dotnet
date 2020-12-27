namespace NationalParks.Models
{
    public class NationalparksDatabaseSettings : INationalparksDatabaseSettings
    {
        public string ParksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUser { get; set; }
        public string DatabasePass { get; set; }
        public string ParksJson { get; set;}
    }

    public interface INationalparksDatabaseSettings
    {
        string ParksCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string DatabaseUser { get; set; }
        string DatabasePass { get; set; }
        string ParksJson { get; set; }
    }
}
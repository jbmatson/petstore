using Azure;

namespace Petstore.Server.Models
{
    public class Pet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; } // "available", "pending", "sold"
        //public List<string> PhotoUrls { get; set; } = new();
        public List<Tag> Tags { get; set; } = new();
    }
}

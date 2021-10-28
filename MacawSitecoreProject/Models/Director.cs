using System;
using System.Text.Json.Serialization;

namespace MacawSitecoreProject.Models
{
    public class Director
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; }

        public Guid MoveId { get; set; }
    }
}
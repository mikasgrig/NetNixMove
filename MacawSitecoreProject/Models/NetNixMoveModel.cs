using System;
using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using MacawSitecoreProject.Clients;
using Newtonsoft.Json;

namespace MacawSitecoreProject.Models
{
    public class NetNixMoveModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("image:")]
        public string Image { get; set; }
        [JsonPropertyName("director")]
        public Director Director { get; set; }

    }
}
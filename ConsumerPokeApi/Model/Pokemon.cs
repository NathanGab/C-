using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConsumerPokeApi.Models
{
    public class Pokemon
    {
        [JsonPropertyName("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }

        [JsonPropertyName("forms")]
        public List<object> Forms { get; set; }

        [JsonPropertyName("game_indices")]
        public List<object> GameIndices { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("held_items")]
        public List<object> HeldItems { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonPropertyName("moves")]
        public List<object> Moves { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("past_abilities")]
        public List<object> PastAbilities { get; set; }

        [JsonPropertyName("past_types")]
        public List<object> PastTypes { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }

        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }

        [JsonPropertyName("types")]
        public List<Type> Types { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        
        public double WeightInKg => Weight / 10.0;
        public double HeightInMeters => Height / 10.0;
    }

    public class Ability
    {
        [JsonPropertyName("ability")]
        public NameUrl AbilityDetail { get; set; }
    }

    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Sprites
    {
        // Aqui você pode mapear campos específicos, como "front_default".
        [JsonPropertyName("front_default")]
        public string FrontDefault { get; set; }
    }

    public class Stat
    {
        [JsonPropertyName("stat")]
        public NameUrl StatDetail { get; set; }

        [JsonPropertyName("base_stat")]
        public int BaseStat { get; set; }

        [JsonPropertyName("effort")]
        public int Effort { get; set; }
    }

    public class Type
    {
        [JsonPropertyName("type")]
        public NameUrl TypeDetail { get; set; }
    }

    public class NameUrl
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace LocationsApp
{
    // Works whether record or class
    public record LocationRecord
    {
        // Property must match JSON exactly (it *is* case sensitive).
        // This annotation specifies to the client what the JSON field name looks like.
        [JsonPropertyName("name")]
        public string Name { get; init; }  // the block is required!

        // Error caused by the JSON file changed (?) to use 'position' instead of 'location'
        [JsonPropertyName("position")] 
        public List<float> Position { get; init; } // the block is required!
    }
}
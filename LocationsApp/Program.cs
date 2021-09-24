using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationsApp
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();
        private const string DataUrl = "https://raw.githubusercontent.com/chyld/datasets/main/markers.json";

        static async Task Main(string[] args)
        {
            await ProcessLocations();
        }
        
        private static async Task ProcessLocations()
        {
            var streamTask = Client.GetStreamAsync(DataUrl);
            var locationRecords = await JsonSerializer.DeserializeAsync<List<LocationRecord>>(await streamTask);
            
            foreach (var location in locationRecords)
                Console.WriteLine($"{location.Name} - {location.Position[0]}, {location.Position[1]}");
        }
    }
}
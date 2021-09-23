using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocationsApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string DataUrl = "https://raw.githubusercontent.com/chyld/datasets/main/markers.json";
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        
        private static async Task ProcessRepositories()
        {
            var streamTask = client.GetStreamAsync(DataUrl);
            var repositories = await JsonSerializer.DeserializeAsync<List<LocationRepository>>(await streamTask);
            
            foreach (var repo in repositories)
                Console.WriteLine(repo.Location[0]);
        }
    }
}
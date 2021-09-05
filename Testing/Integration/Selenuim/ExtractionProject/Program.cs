using ExtractionProject.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

Console.WriteLine("I sure miss the old class style of coding!");

 async Task<IEnumerable<State>> GetStatesAsync(string filename)
{
    string file = $"Data/{filename}.json";
    using FileStream openStream = File.OpenRead(file);
    return await JsonSerializer.DeserializeAsync<List<State>>(openStream);
}

var name = "data";

var g = await GetStatesAsync(name);

foreach (var state in g)
{
    Console.WriteLine($"{state.city} : {state.zip}");
}

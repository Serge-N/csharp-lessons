using ExtractionProject.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

var name = "data";
var TexaStates = await GetStatesAsync(name);

AcquireDataAsyn();


async Task<IEnumerable<State>> GetStatesAsync(string filename)
{
    string file = $"Data/{filename}.json";
    using FileStream openStream = File.OpenRead(file);
    return await JsonSerializer.DeserializeAsync<List<State>>(openStream);
}

void SaveDataAync()
{

}

void UploadDataAsync()
{

}


void AcquireDataAsyn()
{
    Console.WriteLine("Data acquisition intiated.");
    Console.WriteLine("This is for academic purposes only.\n");

    IWebDriver driver = new ChromeDriver
    {
        Url = "https://www.google.com/maps"
    };

    IWebElement searchBox = driver.FindElement(By.Id("searchboxinput"));

    IWebElement searchButton = driver.FindElement(By.Id("searchbox-searchbutton"));

    foreach (var state in TexaStates.OrderBy(x => x.country))
    {
        Console.WriteLine($"Extracting areas around {state.city} with zip of {state.zip}");

        searchBox.SendKeys($"Apartment complex in {state.zip}");
        searchButton.Click();

        Thread.Sleep(20000);

        IList<IWebElement> Results = driver.FindElements(By.PartialLinkText("https://www.google.com/maps/place/")); // needs replacement with xpath

        Thread.Sleep(20000);

        Console.WriteLine($"Appartments : {Results.Count()}");

        Console.WriteLine("Exiting browser");
        driver.Quit();
        break;
    }
}
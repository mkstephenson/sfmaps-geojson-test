using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using nietras.SeparatedValues;
using Syncfusion.Maui.Maps;

namespace TestMapRender;

public partial class MainPage : ContentPage
{
  private readonly HttpClient _client;

  public MainPage()
  {
    InitializeComponent();
    _client = new HttpClient();
  }

  private async void MainPage_OnLoaded(object? sender, EventArgs e)
  {
    var jsonSource = await _client.GetFromJsonAsync<JsonObject>("https://raw.githubusercontent.com/mkstephenson/sfmaps-geojson-test/refs/heads/main/biomes.json");
    var features = jsonSource["features"].AsArray();
    foreach (var feature in features)
    {
      var pointSource = feature["geometry"]["coordinates"][0].AsArray();
      var coords = pointSource.Select(p => (p[0].GetValue<double>(), p[1].GetValue<double>()))
        .ToList();
    }
  }
}
using BlazorServer.Data;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages;

public partial class FetchData
{
    private WeatherForecast[]? forecasts;

    [Inject]
    public WeatherForecastService? ForecastService { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if (ForecastService is not null)
        {
            forecasts = await ForecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
        }
    }
}

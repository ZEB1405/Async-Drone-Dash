// Receive drones - use AsyncDroneService - start multiple drone flights
// use Task.WhenAll to wait for all flights to complete
// Handle exceptions that may occur during API requests and flights

using Async_Drone_Dash.Models;

public class ControlTowerService(
    AsyncDroneService asyncDroneService,
    DroneApiService droneApiService)
{
    private const string ApiUrl =
    "https://jsonplaceholder.typicode.com/todos/4";
    private readonly AsyncDroneService _asyncDroneService = asyncDroneService;
    private readonly DroneApiService _droneApiService = droneApiService;

    public async Task StartFlightsAsync(List<DroneModel> drones)
    {
        var flightTasks = new List<Task>();

        try
        {
            // Get data from the API
            var apiData = await _droneApiService.GetDataAsync(
                ApiUrl);

            Console.WriteLine($"API Data: {apiData}");

            foreach (var drone in drones)
            {
                if (apiData.Completed)
                {
                    drone.DelayMs += 500;
                }

                flightTasks.Add(
                    _asyncDroneService.FlyDroneAsync(drone));
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"API request failed: {ex.Message}");
            return;
        }

        try
        {
            await Task.WhenAll(flightTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"An error occurred during drone flights: {ex.Message}");
        }
    }
}
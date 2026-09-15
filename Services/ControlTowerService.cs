

// Receive drones - use AsyncDroneService - start multiple drone flights - use Task.WhenAll to wait for all flights to complete - Handle any exceptions that may occur during the flights
using Async_Drone_Dash.Models;

public class ControlTowerService(AsyncDroneService asyncDroneService)
{
    private readonly AsyncDroneService _asyncDroneService = asyncDroneService;

    public async Task StartFlightsAsync(List<DroneModel> drones)
    {
        var flightTasks = new List<Task>();

        foreach (var drone in drones)
        {
            flightTasks.Add(_asyncDroneService.FlyDroneAsync(drone));
        }
        try {
            await Task.WhenAll(flightTasks);
        }
        catch (Exception ex)
        {
            // Handle exceptions that may occur during the flights
            Console.WriteLine($"An error occurred during drone flights: {ex.Message}");
        }
    }
}


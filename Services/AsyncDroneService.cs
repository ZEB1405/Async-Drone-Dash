

using Async_Drone_Dash.Models;

public class AsyncDroneService
{
    public async Task FlyDroneAsync(DroneModel drone, int? failureCheckpoint = null)
    {
        Console.WriteLine($"Starting flight for {drone.Name} with a delay of {drone.DelayMs} ms.");

        for (int checkpoint = 1; checkpoint <= drone.MaxCheckpoints; checkpoint++)
        {
            // Artificial engine failure simulation for testing purposes
            if (failureCheckpoint.HasValue && checkpoint == failureCheckpoint.Value)
            {
                throw new Exception($"{drone.Name} encountered an engine failure at checkpoint {checkpoint}. Aborting flight.");
            }
            Console.WriteLine($"{drone.Name} reached checkpoint {checkpoint}.");
            await Task.Delay(drone.DelayMs);
        }

        Console.WriteLine($"{drone.Name} has completed its flight.");

    }
}
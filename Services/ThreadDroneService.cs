

using Async_Drone_Dash.Models;

public class ThreadDroneService
{
    public void FlyDrone(DroneModel drone)
    {
        Console.WriteLine($"Starting flight for {drone.Name} with a delay of {drone.DelayMs} ms.");

        for (int checkpoint = 1; checkpoint <= drone.MaxCheckpoints; checkpoint++)
        {
            Console.WriteLine($"{drone.Name} reached checkpoint {checkpoint}.");
            Thread.Sleep(drone.DelayMs);
        }

        Console.WriteLine($"{drone.Name} has completed its flight.");

    }
}
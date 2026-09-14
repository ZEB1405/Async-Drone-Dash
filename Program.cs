using Async_Drone_Dash.Models;

var drone1 = new DroneModel("Drone Alpha", 5, 500);
var drone2 = new DroneModel("Drone Beta", 5, 700);

var threadDroneService = new ThreadDroneService();

var thread1 = new Thread(() => threadDroneService.FlyDrone(drone1));
var thread2 = new Thread(() => threadDroneService.FlyDrone(drone2));

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine("All drones have completed their flights.");

var asyncDroneService = new AsyncDroneService();

var task1 = asyncDroneService.FlyDroneAsync(drone1, 3);
var task2 = asyncDroneService.FlyDroneAsync(drone2);

try
{
    await Task.WhenAll(task1, task2);

    Console.WriteLine("All drones have completed their flights.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during the flight: {ex.Message}");
}
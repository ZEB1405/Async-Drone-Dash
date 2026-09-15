using Async_Drone_Dash.Models;

Console.WriteLine("=== Async Drone Dash ===");
Console.WriteLine("1. Run Part A - Thread + Join");
Console.WriteLine("2. Run Part B - async/await + Task.WhenAll");
Console.WriteLine("3. Run Part C - HTTP API");
Console.WriteLine("0. Exit");

Console.Write("Choose an option: ");
var choice = Console.ReadKey();

var drone1 = new DroneModel("Drone Alpha", 5, 500);
var drone2 = new DroneModel("Drone Beta", 5, 700);
var threadDroneService = new ThreadDroneService();
var asyncDroneService = new AsyncDroneService();

switch (choice.KeyChar)
{
    case '1':
        // Part A
        var thread1 = new Thread(() => threadDroneService.FlyDrone(drone1));
        var thread2 = new Thread(() => threadDroneService.FlyDrone(drone2));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("All drones have completed their flights.");
        break;

    case '2':
        // Part B
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
        break;

    case '3':
        // Part C
        var httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(5)
        };

        var droneApiService = new DroneApiService(httpClient);
        var controlTowerService = new ControlTowerService(asyncDroneService, droneApiService);

        await controlTowerService.StartFlightsAsync(new List<DroneModel> { drone1, drone2 });
        break;

    case '0':
        return;
}


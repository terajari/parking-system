class Program
{
    private static int parkingSlots;
    private static Dictionary<int, Vehicle> parkingLot;
    static void Main(string[] args)
    {
        parkingSlots = 0;
        parkingLot = new Dictionary<int, Vehicle>();

        Commands run = new Commands(parkingSlots, parkingLot);

        while (true)
        {
            string command = Console.ReadLine();
            string[] commands = command.Split(' ');

            switch (commands[0])
            {
                case "create_parking_lot":
                    int slot = int.Parse(commands[1]);
                    run.CreateParkingLot(slot);
                    break;
                
                case "park":
                    string licensePlate = commands[1];
                    string color = commands[2];
                    string vehicleType = commands[3];
                    
                    run.ParkVehicle(licensePlate, vehicleType, color);
                    break;

                case "leave":
                    slot = int.Parse(commands[1]);
                    run.LeaveVehicle(slot);
                    break;

                case "status":
                    run.PrintStatus();
                    break;

                case "type_of_vehicles":
                    vehicleType = commands[1];
                    run.TypeVehiclesCount(vehicleType);
                    break;

                case "registration_numbers_for_vehicles_with_odd_plate":
                    run.PrintOddPlate();
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    run.PrintEvenPlate();
                    break;

                case "registration_numbers_for_vehicles_with_color":
                    color = commands[1];
                    run.PrintPlateColor(color);
                    break;

                case "slot_numbers_for_vehicles_with_color":
                    color = commands[1];
                    run.PrintSlotByColor(color);
                    break;

                case "slot_number_for_registration_number":
                    licensePlate = commands[1];
                    run.PrintSlotByPlate(licensePlate);
                    break;

                case "help":
                    run.PrintHelp();
                    break;
            }

            if (commands[0] == "exit")
            {
                break;
            }
        }
    }
}   
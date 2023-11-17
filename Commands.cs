class Commands
{
    private Dictionary<int, Vehicle> parkingLot;
    private int parkingSlots;

    public Commands(int parkingSlots, Dictionary<int, Vehicle> parkingLot)
    {
        this.parkingLot = parkingLot;
        this.parkingSlots = parkingSlots;
    }

    public void CreateParkingLot(int slot)
    {
        parkingSlots = slot;
        Console.WriteLine("Created a parking lot with " + parkingSlots + " slots");
    }

    public int GetAvailableSlot()
    {
        for (int i = 1; i <= parkingSlots; i++)
        {
            if (!parkingLot.ContainsKey(i))
            {
                return i;
            }
        }

        return -1;
    }

    public void ParkVehicle(string licensePlate, string vehicleType, string color)
    {
        int slot = GetAvailableSlot();
        if (slot < 0)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }
        parkingLot[slot] = new Vehicle(licensePlate, color, vehicleType);

        Console.WriteLine("Allocated slot number: " + slot);
    }

    public void LeaveVehicle(int slot)
    {
        if (slot > parkingSlots || slot < 1)
        {
            Console.WriteLine("There is no slot number " + slot);
            return;
        }
        if (!parkingLot.ContainsKey(slot))
        {
            Console.WriteLine("Slot number " + slot + " is already empty");
            return;
        }

        parkingLot.Remove(slot);
        Console.WriteLine("Slot number " + slot + " is free");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Slot No.    Registration No.    Color    Type");

        foreach(KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            int slotNo = entry.Key;
            Vehicle vehicle = entry.Value;

            Console.WriteLine(slotNo + "          " + vehicle.GetLicensePlate() + "          " + vehicle.GetColor() + "          " + vehicle.GetVehicleType());
        }
    }
    
    public void TypeVehiclesCount(string vehicleType)
    {
        if (!parkingLot.Any())
        {
            Console.WriteLine("Not found");
            return;
        }

        int count = 0;

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (entry.Value.GetVehicleType() == vehicleType)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    public bool IsOddPlate(string plate)
    {
        string digitPlate = new string(plate.Where(char.IsDigit).ToArray());
        int digit = int.Parse(digitPlate);

        if (digit % 2 != 0)
        {
            return true;
        }

        return false;
    }

    public bool IsEvenPlate(string plate)
    {
        string digitPlate = new string(plate.Where(char.IsDigit).ToArray());
        int digit = int.Parse(digitPlate);

        if (digit % 2 == 0)
        {
            return true;
        }

        return false;
    }

    public void PrintOddPlate()
    {
        List<string> oddPlate = new List<string>();

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (IsOddPlate(entry.Value.GetLicensePlate()))
            {
                oddPlate.Add(entry.Value.GetLicensePlate());
            }
        }

        Console.WriteLine(string.Join(", ", oddPlate));
    }

    public void PrintEvenPlate()
    {
        List<string> evenPlate = new List<string>();

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (IsEvenPlate(entry.Value.GetLicensePlate()))
            {
                evenPlate.Add(entry.Value.GetLicensePlate());
            }
        }

        Console.WriteLine(string.Join(", ", evenPlate));
    }

    public void PrintPlateColor(string color)
    {
        if (!parkingLot.Any())
        {
            Console.WriteLine("Not found");
            return;
        }

        List<string> colorPlate = new List<string>();
        bool found = false;

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (entry.Value.GetColor() == color)
            {
                colorPlate.Add(entry.Value.GetLicensePlate());
                found = true;
            }
        }

        if (!found) {
            Console.WriteLine("Not found");
        } else 
        {
            Console.WriteLine(string.Join(", ", colorPlate));
        }
    }

    public void PrintSlotByColor(string color)
    {
        if (!parkingLot.Any())
        {
            Console.WriteLine("Not found");
            return;
        }
        List<int> colorSlot = new List<int>();
        bool found = false;

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (entry.Value.GetColor() == color)
            {
                colorSlot.Add(entry.Key);
                found = true;
            }
        }

        if (!found) {
            Console.WriteLine("Not found");
        } else 
        {
            Console.WriteLine(string.Join(", ", colorSlot));
        }
    }

    public void PrintSlotByPlate(string plate)
    {
        if (!parkingLot.Any())
        {
            Console.WriteLine("Not found");
            return;
        }

        List<int> plateSlot = new List<int>();
        bool found = false;

        foreach (KeyValuePair<int, Vehicle> entry in parkingLot)
        {
            if (entry.Value.GetLicensePlate() == plate)
            {
                plateSlot.Add(entry.Key);
                found = true;
            }
        }

        if (!found) {
            Console.WriteLine("Not found");
        } else 
        {
            Console.WriteLine(string.Join(", ", plateSlot));
        }
    }

    public void PrintHelp()
    {
        Console.WriteLine("create_parking_lot <number> - Create a parking lot with <number> slots");
        Console.WriteLine("park <registration_number> <color> <type> - Park a vehicle with <registration_number>, <color>, <type>");
        Console.WriteLine("leave <slot_number> - Leave a vehicle at <slot_number>");
        Console.WriteLine("status - Print the status of the parking lot");
        Console.WriteLine("type_of_vehicles <type> - Print the number of vehicles with <type>");
        Console.WriteLine("registration_numbers_for_vehicles_with_color <color> - Print the registration numbers of vehicles with <color>");
        Console.WriteLine("slot_numbers_for_vehicles_with_color <color> - Print the slot numbers of vehicles with <color>");
        Console.WriteLine("slot_number_for_registration_number <registration_number> - Print the slot number of vehicle with <registration_number>");
        Console.WriteLine("registration_numbers_for_vehicles_with_odd_plate - Print the registration numbers of vehicles with odd plate");
        Console.WriteLine("registration_numbers_for_vehicles_with_even_plate - Print the registration numbers of vehicles with even plate");
        Console.WriteLine("slot_numbers_for_vehicles_with_color <color> - Print the slot numbers of vehicles with <color>");
        Console.WriteLine("slot_number_for_registration_number <registration_number> - Print the slot number of vehicle with <registration_number>");
    }
}
class Vehicle
{
    private string _licensePlate;
    private string _vehicleType;
    private string _color;

    public Vehicle(string licensePlate, string color, string vehicleType)
    {
        _licensePlate = licensePlate;
        _color = color;
        _vehicleType = vehicleType;
    }

    public string GetLicensePlate()
    {
        return _licensePlate;
    }

    public string GetVehicleType()
    {
        return _vehicleType;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetLicensePlate(string licensePlate)
    {
        _licensePlate = licensePlate;
    }

    public void SetType(string type)
    {
        _vehicleType = type;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    
}
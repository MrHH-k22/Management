public class PersonalVehicle : Vehicle
{
    public PersonalVehicle() { }

    public PersonalVehicle(string carID, string description, int capacity, bool insurance, string brand, DateTime purchaseYear, double price, double traveledKM)
        : base(carID, description, capacity, insurance, brand, purchaseYear, price, traveledKM)
    {

    }
}
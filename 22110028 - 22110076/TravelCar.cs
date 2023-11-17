public class TravelCar : Vehicle
{
    public TravelCar() { }

    public TravelCar(string carID, string description, int capacity, bool insurance, string brand, DateTime purchaseYear, double price, double traveledKM)
        : base(carID, description, capacity, insurance, brand, purchaseYear, price, traveledKM)
    {

    }
}
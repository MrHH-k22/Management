public class WeddingCar : Vehicle
{
    public WeddingCar() { }

    public WeddingCar(string carID, string description, int capacity, bool insurance, string brand, DateTime purchaseYear, double price, double traveledKM)
        : base(carID, description, capacity, insurance, brand, purchaseYear, price, traveledKM)
    {

    }
}
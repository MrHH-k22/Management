public class Vehicle
{
    protected string carID;
    protected string description;
    protected int capacity;
    protected string type;
    protected bool insurance;
    protected string brand;
    protected DateTime purchaseYear;
    protected double price;
    protected double traveledKM;

    public Vehicle() 
    { 
    
    }

    public Vehicle(string carID, string description, int capacity, bool insurance, string brand, DateTime purchaseYear, double price, double traveledKM)
    {
        this.carID = carID;
        this.description = MyString.Capitalize(description);
        this.capacity = capacity;
        type = GetType().Name;
        this.insurance = insurance;
        this.brand = MyString.Capitalize(brand);
        this.purchaseYear = purchaseYear;
        this.price = price;
        this.traveledKM = traveledKM;
    }

    public void Convert(Vehicle vh)
    {
        carID = vh.carID;
        description = vh.description;
        capacity = vh.capacity;
        type = GetType().Name;
        insurance = vh.insurance;
        brand = vh.brand;
        purchaseYear = vh.purchaseYear;
        price = vh.price;
        traveledKM = vh.traveledKM;
    }

    public string CarID 
    { 
        get { return carID; } 
        set { carID = value; } 
    }
    public string Description 
    { 
        get { return description; } 
        set { description = value; } 
    }
    public int Capacity 
    { 
        get { return capacity; } 
        set { capacity = value; } 
    }
    public string Type 
    { 
        get { return type; } 
        set { type = value; } 
    }
    public bool Insurance 
    { 
        get { return insurance; } 
        set { insurance = value; } 
    }
    public string Brand 
    { 
        get {  return brand; } 
        set {  brand = value; } 
    }
    public DateTime PurchaseYear 
    { 
        get { return purchaseYear; } 
        set { purchaseYear = value; } 
    }
    public double Price 
    { 
        get { return price; } 
        set { price = value; } 
    }    
    public double TraveledKM 
    { 
        get {  return traveledKM; } 
        set {  traveledKM = value; } 
    }
}
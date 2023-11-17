using System.Net;
using System.Xml.Linq;

public class Company
{
    private List<Owner> owners = new List<Owner>();
    private List<Hirer> hirers = new List<Hirer>();
    private List<Vehicle> vehicles = new List<Vehicle>();
    private static List<Contract> contracts = new List<Contract>(); 
    public Company() 
    { 
    
    }

    public List<Vehicle> Vehicles
    {
        get { return vehicles; }
        set { vehicles = value; }
    }

    public List<Contract> Contracts
    {
        get { return contracts; }
        set { contracts = value; }

    }
    public List<Hirer> Hirers
    {
        get { return hirers;}
        set { hirers = value; }
    }
    public List<Owner> Owners
    {
        get { return owners; }
        set { owners = value; }
    }
    public void addOwner (Owner owner)
    {
        owners.Add(owner);
    }
    public void addHirer(Hirer hirer)
    {
        hirers.Add(hirer);
    }
    public void addContract (Contract contract)
    {
        contracts.Add(contract);
    }

    public void createContract(Hirer hirer, Vehicle vehicle, Owner owner, int numRentDays, string purpose, DateTime rentDay, double deposit)
    {
        Contract contract = new Contract(hirer,vehicle,owner,numRentDays,purpose,rentDay,deposit);
        contracts.Add(contract);
    }

    public void readOwners(string filename)
    {
        List<Person> people = new List<Person>();
        people = File.ReadCsvFile(filename);
        foreach (var person in people)
        {
            Owner or = new Owner();
            or.Convert(person);
            owners.Add(or);
        }
    }

    public void readContracts(string filename)
    {
        contracts = File.ReadContractCsvFile(filename,this);
    }

    public void writeContracts(string filename)
    {
        File.WriteContractCsvFile(this, filename);
    }

    public void writeOwners(string filename)
    {
        List<Person> people = new List<Person>();
        foreach (var person in owners)
        {
            Person ps = new Person();
            ps.Convert(person);
            people.Add(ps);
        }
        File.WriteCsvFile(people, filename);
    }

    public void readHirers(string filename)
    {
        List<Person> people = new List<Person>();
        people = File.ReadCsvFile(filename);
        foreach (var person in people)
        {
            Hirer hr = new Hirer();
            hr.Convert(person);
            hirers.Add(hr);
        }
    }

    public void writeHirers(string filename)
    {
        List<Person> people = new List<Person>();
        foreach (var person in hirers)
        {
            Person ps = new Person();
            ps.Convert(person);
            people.Add(ps);
        }
        File.WriteCsvFile(people, filename);
    }

    public void readVehicles(string filename)
    {
        List<Vehicle> vhs = new List<Vehicle>();
        vhs = File.ReadVehicleCsvFile(filename);
        foreach (var vehicle in vhs)
        {
            switch (vehicle.Type)
            {
                case "TrainingCar":
                    TrainingCar trc = new TrainingCar();
                    trc.Convert(vehicle);
                    vehicles.Add(trc);
                    break;
                case "TravelCar":
                    TravelCar tc = new TravelCar();
                    tc.Convert(vehicle);
                    vehicles.Add(tc);
                    break;
                case "WeddingCar":
                    WeddingCar wc = new WeddingCar();
                    wc.Convert(vehicle);
                    vehicles.Add(wc);
                    break;
                case "PersonalVehicle":
                    PersonalVehicle pv = new PersonalVehicle();
                    pv.Convert(vehicle);
                    vehicles.Add(pv);
                    break;
                default:
                    break;
            }
        }
    }

    public void writeVehicles(string filename)
    {
        File.WriteVehicleCsvFile(vehicles, filename);
    }

    public void displayContract()
    {
        Console.ForegroundColor = Util.CSTitle;
        Console.WriteLine("Hirer name, owner name, Vehicle description, purpose, remaining day, total Money ");
        foreach (Contract contract in contracts)
        {
            contract.display();
        }
        Console.ResetColor();
    }

    public void update()
    {
        foreach(Contract contract in contracts)
        {
            contract.Totalmoney =  contract.TotalMoney();
        }
    }
}
using LINQtoCSV;
using System;
using System.Globalization;

public class File
{
    
    
    public static List<Person> ReadCsvFile(string filePath)
    {
        List<Person> people = new List<Person>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header line (if any)
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length >= 5)
                    {
                        string name = values[0].Trim();
                        string address = values[1].Trim();
                        string phoneNo = values[2].Trim();
                        string nationalID = values[3].Trim();
                        DateTime birth;

                        if (DateTime.TryParse(values[4].Trim(), out birth))
                        {
                            // Successfully parsed DateTime
                            people.Add(new Person { Name = name, Address = address, PhoneNo = phoneNo, NationalID = nationalID, Birth = birth });
                        }
                        else
                        {
                            // Handle parsing failure
                            Console.WriteLine($"Failed to parse DateTime for {name}");
                        }
                    }
                    else
                    {
                        // Handle invalid CSV line
                        Console.WriteLine($"Invalid CSV line: {line}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle file reading or parsing errors
            Console.WriteLine($"Error reading CSV file: {ex.Message}");
        }
        return people;
    }
    public static List<Vehicle> ReadVehicleCsvFile(string filePath)
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header line (if any)
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length >= 9)
                    {
                        string carID = values[0].Trim();
                        string description = values[1].Trim();
                        int capacity = int.Parse(values[2].Trim());
                        string type = values[3].Trim();
                        bool insurance = bool.Parse(values[4].Trim());
                        string brand = values[5].Trim();
                        DateTime purchaseYear = DateTime.Parse(values[6].Trim());
                        double price = double.Parse(values[7].Trim());
                        double traveledKM = double.Parse(values[8].Trim());

                        vehicles.Add(new Vehicle
                        {
                            CarID = carID,
                            Description = description,
                            Capacity = capacity,
                            Type = type,
                            Insurance = insurance,
                            Brand = brand,
                            PurchaseYear = purchaseYear,
                            Price = price,
                            TraveledKM = traveledKM
                        });
                    }
                    else
                    {
                        // Handle invalid CSV line
                        Console.WriteLine($"Invalid CSV line: {line}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle file reading or parsing errors
            Console.WriteLine($"Error reading Vehicle CSV file: {ex.Message}");
        }

        return vehicles;
    }

    public static List<Contract> ReadContractCsvFile(string filePath, Company company)
    {
        List<Contract> contracts = new List<Contract>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the header line (if any)
                string header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values.Length >= 10)
                    {
                        int HirerIndex = int.Parse(values[0].Trim());
                        int VehicleIndex = int.Parse(values[1].Trim());
                        int OwnerIndex = int.Parse(values[2].Trim());
                        int numRentDays = int.Parse(values[3].Trim());
                        string purpose = values[4].Trim();
                        DateTime rentDate = DateTime.Parse(values[5].Trim());
                        double deposit = double.Parse(values[6].Trim());
                        string OwnerComment = values[7].Trim();
                        double HirerStar = double.Parse(values[8].Trim());
                        string HirerComment = values[9].Trim();
                        Contract x = new Contract(company.Hirers[HirerIndex], company.Vehicles[VehicleIndex], company.Owners[OwnerIndex], 
                            numRentDays, purpose, rentDate, deposit);
                        x.createFeedbackForHirer(HirerComment,HirerStar);
                        x.createFeedbackForOwner(OwnerComment,0);
                        contracts.Add(x);
                    }
                    else
                    {
                        // Handle invalid CSV line
                        Console.WriteLine($"Invalid CSV line: {line}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle file reading or parsing errors
            Console.WriteLine($"Error reading Contract CSV file: {ex.Message}");
        }

        return contracts;
    }
    public static void WriteContractCsvFile(Company company, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {

                // Write header
                writer.WriteLine("Hirer index,Vehicle index,Owner index,number of rent days,purpose,rent date,deposit, Owner's comment, Hirer's star, Hirer's comment");

                // Write data
                foreach (var contract in company.Contracts)
                {
                    int Hirerindex = company.Hirers.IndexOf(contract.Hirer);
                    int Vehicleindex = company.Vehicles.IndexOf(contract.Vehicle);
                    int Ownerindex = company.Owners.IndexOf(contract.Owner);
                    string line = $"{Hirerindex},{Vehicleindex},{Ownerindex},{contract.NumRentDays},{contract.Purpose},{contract.RentDay:yyyy-MM-dd},{contract.Deposit},{contract.FeedbackOwner.Comment},{contract.FeedbackHirer.Star},{contract.FeedbackHirer.Comment}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"CSV file written successfully to: {filePath}");
        }
        catch (Exception ex)
        {
            // Handle file writing errors
            Console.WriteLine($"Error writing CSV file: {ex.Message}");
        }
    }

    public static void WriteCsvFile(List<Person> people, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header
                writer.WriteLine("Name,Address,PhoneNo,NationalID,Birth");

                // Write data
                foreach (var person in people)
                {
                    string line = $"{person.Name},{person.Address},{person.PhoneNo},{person.NationalID},{person.Birth:yyyy-MM-dd}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"CSV file written successfully to: {filePath}");
        }
        catch (Exception ex)
        {
            // Handle file writing errors
            Console.WriteLine($"Error writing CSV file: {ex.Message}");
        }
    }
    public static void WriteVehicleCsvFile(List<Vehicle> vehicles, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header
                writer.WriteLine("CarID,Description,Capacity,Type,Insurance,Brand,PurchaseYear,Price,TraveledKM");

                // Write data
                foreach (var vehicle in vehicles)
                {
                    string line = $"{vehicle.CarID},{vehicle.Description},{vehicle.Capacity},{vehicle.Type},{vehicle.Insurance},{vehicle.Brand},{vehicle.PurchaseYear:yyyy-MM-dd},{vehicle.Price},{vehicle.TraveledKM}";
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine($"CSV file written successfully to: {filePath}");
        }
        catch (Exception ex)
        {
            // Handle file writing errors
            Console.WriteLine($"Error writing CSV file: {ex.Message}");
        }
    }
}
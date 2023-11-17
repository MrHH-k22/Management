using System;

void menu()
{
    int choice;
    Console.WriteLine("1. Read file");

        
}

class GFG
{
    private protected static void Main()
    {
        Company companyA = new Company();
        companyA.readHirers("Hirers.csv");
        companyA.readOwners("Owners.csv");
        companyA.readVehicles("Vehicles.csv");
        companyA.readContracts("Contracts.csv");

        
        companyA.displayContract();

        Console.WriteLine();
        ExtraCost extras = new ExtraCost();
        companyA.Contracts[0].addExtraCost("Window damage", 20);
        companyA.Contracts[0].addExtraCost("Wheel damage", 20);
        companyA.Contracts[0].addExtraCost("Light damage", 20);
        companyA.Contracts[1].addExtraCost("Pumb damage", 20);
        companyA.Contracts[1].addExtraCost("Door damage", 20);
        companyA.Contracts[2].addExtraCost("Window damage", 20);
        companyA.update();
        companyA.displayContract();

        Console.WriteLine();
        companyA.writeHirers("ListOfHirers.csv");
        companyA.writeOwners("ListOfOwners.csv");
        companyA.writeVehicles("ListOfVehicles.csv");
        companyA.writeContracts("ListOfContracts.csv");
    }
}
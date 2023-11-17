using System.Diagnostics.Contracts;

public class Hirer : Person
{
    public Hirer() 
    { 
    
    }
    public Hirer(string name, string address, string phoneNo, string nationalID, DateTime birth)
        : base(name, address, phoneNo, nationalID, birth) { }


}


using System.Diagnostics.Contracts;

public class Owner : Person
{
    public Owner()
    {
    
    }
    public Owner(string name, string address, string phoneNo, string nationalID, DateTime birth)
        : base(name, address, phoneNo, nationalID, birth) { }
}


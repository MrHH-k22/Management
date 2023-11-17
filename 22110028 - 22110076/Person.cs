public class Person
{
    protected string name;
    protected string address;
    protected string phoneNo;
    protected string nationalID;
    protected DateTime birth;
    public Person() 
    {
    
    }
    public Person(string name, string address, string phoneNo, string nationalID, DateTime birth)
    {
        this.name = MyString.Capitalize(name);
        this.address = MyString.Capitalize(address);
        this.phoneNo = phoneNo;
        this.nationalID = nationalID;
        this.birth = birth;
    }
    public void Convert(Person person)
    {
        name = person.name;
        address = person.address;
        phoneNo = person.phoneNo;
        nationalID = person.nationalID;
        birth = person.birth;
    }
    public string NationalID
    {
        get { return nationalID; }
        set { nationalID = value; }
    }
    public string Name
    {
        get { return name;}
        set { name = value; }
    }
    public string Address
    {
        get { return address;}
        set { address = value; }
    }
    public string PhoneNo
    { 
        get { return phoneNo;} 
        set {  phoneNo = value; } 
    }
    public DateTime Birth
    {
        get { return birth;}
        set { birth = value; }
    }
}
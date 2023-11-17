using System.Diagnostics;
using System;
using System.Security.Cryptography.X509Certificates;

public class Contract
{
    private Hirer hirer;
    private Vehicle vehicle;
    private Owner owner;
    private double deposit;
    private int numRentDays;
    private string purpose;
    private DateTime rentDay;
    private DateTime expiredDay;
    private ExtraCost excost = new ExtraCost();
    private Discount discount = new Discount();
    private double totalMoney;
    private bool returnCar;
    private Person driver;
    private FeedbackForOwner feedbackForOwner = new FeedbackForOwner();
    private FeedbackForHirer feedbackForHirer = new FeedbackForHirer();
    public void HireDriver(Person driver)
    {
        this.driver = driver;
    }
    public Hirer Hirer
    {
        get { return hirer; }
        set { hirer = value; }
    }
    public Vehicle Vehicle
    {
        get { return vehicle; }
        set { vehicle = value; }
    }

    public Owner Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    public int NumRentDays
    { 
        get { return numRentDays; }
        set {  numRentDays = value; }
    }

    public string Purpose
    {
        get { return purpose; }
        set { purpose = value; }
    }

    public DateTime RentDay
    {
        get { return rentDay; }
        set { rentDay = value; }
    }

    public double Deposit
    {
        get { return deposit; }
        set { deposit = value; }
    }



    public double Totalmoney
    {
        get { return totalMoney; }
        set { totalMoney = value; }
    }

    public FeedbackForHirer FeedbackHirer
    {
        get { return feedbackForHirer; }
        set { feedbackForHirer = value; }
    }

    public FeedbackForOwner FeedbackOwner
    {
        get { return feedbackForOwner; }
        set { feedbackForOwner = value; }
    }
    public Contract() { }
    public Contract(Hirer hirer, Vehicle vehicle, Owner owner, int numRentDays, string purpose, DateTime rentDay, double deposit)
    {
        this.hirer = hirer;
        this.vehicle = vehicle;
        this.owner = owner;
        this.numRentDays = numRentDays;
        this.purpose = purpose;
        this.rentDay = rentDay;
        returnCar = false;
        this.deposit = deposit;
        expiredDay = rentDay.AddDays(numRentDays);
        totalMoney = TotalMoney();
    }


    public void addExtraCost(string des,double cost)
    {
        excost.addCost(des,cost);
    }

    public double TotalMoney()
    {
        if (!returnCar)
        {
            totalMoney = vehicle.Price - discount.calculate(rentDay, hirer, owner) + excost.caculate(vehicle.Insurance) + fine();
        }
        totalMoney -= deposit;
        return totalMoney;
    }
    
    public double fine()
    {
        DateTime date = rentDay;
        return date.AddDays(numRentDays).Date < DateTime.Now.Date ? remainingDay() * 10 : 0;
    }

    public int remainingDay()
    {

        return (expiredDay - DateTime.Now).Days;
    }

    public void payment(double paymoney)
    {
        if (totalMoney <= paymoney) totalMoney = 0;
        else totalMoney -= paymoney;
    }

    public bool Checkcar()
    {
        return excost.caculate(vehicle.Insurance) >= 0.5 * vehicle.Price? false : true;
    }

    public void ReturnCar()
    {
        if (!returnCar)
        {
            if (Checkcar())
            {
                returnCar = true;
            }
        }
    }

    public void createFeedbackForHirer(string comment, double star)
    {
        feedbackForHirer.Create(comment, star);
    }

    public void createFeedbackForOwner(string comment, double star)
    {
        feedbackForOwner.Create(comment, star);
    }

    public void display()
    {
        Console.ForegroundColor = Util.CSContent;
        Console.WriteLine(hirer.Name + ", " + owner.Name + ", " + vehicle.Description + ", " + purpose + ", " + remainingDay() + ", " + totalMoney);
        Console.ResetColor();
    }

}


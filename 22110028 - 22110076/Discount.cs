
public class Discount
{
    private List<DateTime> startDate = new List<DateTime>(); // Tet, Trung thu, QTLD, ......
    private List<DateTime> endDate = new List<DateTime>(); // Tet, Trung thu, QTLD, ......
    private List<string> descriptions = new List<string>(); // 50 nam, dot khuyen mai, .....
    private List<double> discounts = new List<double>(); // So tien giam
    public void addDiscount(DateTime startDate, DateTime endDate, string description, double discout)
    {
        this.startDate.Add(startDate);
        this.endDate.Add(endDate);
        descriptions.Add(description);
        discounts.Add(discout);
    }
    public Discount()
    {
        DateTime sDate;
        DateTime eDate;
        string des;
        double dis = 50;

        sDate = new DateTime(1, 4, 30);
        eDate = new DateTime(1, 4, 30);
        des = "Giai phong mien Nam";
        startDate.Add(sDate);
        endDate.Add(eDate);
        descriptions.Add(des);
        discounts.Add(dis);

        sDate = new DateTime(1, 11, 20);
        eDate = new DateTime(1, 11, 20);
        des = "Ngay nha giao Viet Nam";
        startDate.Add(sDate);
        endDate.Add(eDate);
        descriptions.Add(des);
        discounts.Add(dis);

        sDate = new DateTime(1, 3, 8);
        eDate = new DateTime(1, 3, 8);
        des = "Quoc te phu nu";
        startDate.Add(sDate);
        endDate.Add(eDate);
        descriptions.Add(des);
        discounts.Add(dis);

        sDate = new DateTime(1, 2, 5);
        eDate = new DateTime(1, 2, 18);
        des = "Tet am lich Viet Nam";
        startDate.Add(sDate);
        endDate.Add(eDate);
        descriptions.Add(des);
        discounts.Add(dis);
    }

    public double calculate(DateTime day, Hirer hirer, Owner owner)
    {
        double sum = 0;
        DateTime temp = new DateTime(1, day.Month, day.Day);
        if (isRegularCostumer(hirer)) sum += 50;
        for (int i = 0; i < discounts.Count; i++)
        {
            if (temp.Date >= startDate[i].Date && temp.Date <= endDate[i].Date) sum += discounts[i];    
        }
        return sum;
    }

    public bool isRegularCostumer(Hirer hirer) 
    {
        int count = 0;
        Company x = new Company();
        foreach(Contract cont in x.Contracts) 
        {
            if (cont.Hirer == hirer) count++;
        }
        if (count > 5) return true;
        return false;

    }
}



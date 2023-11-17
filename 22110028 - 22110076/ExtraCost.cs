public class ExtraCost
{
    List<string> descriptions = new List<string>();
    List<double> costs = new List<double>();
    public void addCost(string descrip, double cost)
    {
        descriptions.Add(descrip);
        costs.Add(cost);
    }
    public ExtraCost() { }
    public double caculate(bool insurance)
    {
        if (insurance) return 0;
        double sum = 0;
        foreach (double cost in costs)
        {
            sum += cost;
        }
        return sum;
    }
}


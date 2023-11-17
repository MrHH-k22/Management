public class Feedback
{
    protected string comment = "";
    protected double star = 0;
    public virtual void Create(string comment, double star)
    {
        this.comment = comment;
        this.star = star;
    }
    public Feedback()
    {

    }

    public string Comment
    {
        get { return comment; }
        set { comment = value; }
    }

    public double Star
    {
        get { return  star; }
        set { star = value; }
    }

}
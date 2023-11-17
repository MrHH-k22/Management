public class FeedbackForOwner : Feedback
{
    public FeedbackForOwner()
    {

    }
    public override void Create(string comment, double star)
    {
        this.comment = comment;
    }
}
namespace Data_Analysis;

public class Amswer
{
    public bool IsFinalAnswer;
    public string Question;

    public Amswer(string question, bool isFinalAnswer = false)
    {
        this.Question = question;
        this.IsFinalAnswer = isFinalAnswer;

    }
}
namespace Data_Analysis;

public class FromDb
{
    public IDictionary<string, List<string>> db { get; }
    public FromDb()
    {
        IDictionary<string, List<string>> db = new Dictionary<string, List<string>>();
        
    }
}
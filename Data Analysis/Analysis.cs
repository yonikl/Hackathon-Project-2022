using System.Collections.Concurrent;
using System.Text;
using System.Text.Json.Nodes;

namespace Data_Analysis;

public class Analysis
{
    private FromDb db = new FromDb();
    public Amswer TryToDiagnose(List<string> symptoms)
    {
        IDictionary<string, int> prediction = new Dictionary<string, int>();
        foreach(var item in db.db) // initialize
        {
            prediction.Add(item.Key, 0);
        }

        foreach (var item in db.db)
        {
            foreach (var symptom in symptoms)
            {
                if (item.Value.Contains(symptom))
                {
                    prediction[item.Key]++;
                }
            }
        }
        Amswer s = new Amswer("esf");
        return s;
    }
}
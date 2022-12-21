using System.Collections.Concurrent;
using System.Text;
using System.Text.Json.Nodes;

namespace Data_Analysis;

public class Analysis
{
    private FromDb? _db;
    private List<string>? _symptoms;
    private IDictionary<string, double>? _prediction;
    // private List<string>? _deniedSymptoms;

    public Analysis()
    {
        _db = new FromDb();
    }
    public Amswer TryToDiagnose(List<string> symptoms)
    {
        
        this._symptoms = symptoms;
        _prediction = new Dictionary<string, double>();
        foreach(var item in _db!.Db) // initialize
        {
            _prediction.Add(item.Key, 0);
        }


        foreach (var item in _db.Db)
        {
            foreach (var symptom in symptoms)
            {
                if (item.Value.Contains(symptom.ToLower()))
                {
                    _prediction[item.Key]++;
                }
            }


        }
        foreach (var predict in _prediction)
        {
            _prediction[predict.Key] /= _db.Db[predict.Key].Count;
        }

        Tuple<bool, string?> isTherePrediction = IsTherePrediction()!;
        if (isTherePrediction.Item1)
        {

            return new Amswer(isTherePrediction.Item2!, isTherePrediction.Item1);
        }
        else
        {
            return new Amswer(NextQuestion());
        }

    }
    
    

    private Tuple<bool, string?>? IsTherePrediction()
    {
        foreach (var item in _prediction!)
        {
            if (item.Value >= 0.9)
            {
                return new Tuple<bool, string?>(true, item.Key);
            }

        }

        return new Tuple<bool, string?>(false, null);
    }

    private string NextQuestion()
    {
        
        foreach (var item in _db.DistributionPriority)
        {
            if (_symptoms!.Contains(item))
            {
                continue;
            }

            return item;
        }

        return "";
    }
}
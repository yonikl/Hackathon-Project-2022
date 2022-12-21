using System.Collections.Concurrent;
using System.Text;
using System.Text.Json.Nodes;

namespace Data_Analysis;

public class Analysis
{
    private readonly FromDb _db = new FromDb();
    private List<string>? _symptoms;
    private IDictionary<string, int>? _prediction;
    public Amswer TryToDiagnose(List<string> symptoms)
    {
        this._symptoms = symptoms;
        _prediction = new Dictionary<string, int>();
        foreach(var item in _db.Db) // initialize
        {
            _prediction.Add(item.Key, 0);
        }

        foreach (var item in _db.Db)
        {
            foreach (var symptom in symptoms)
            {
                if (item.Value.Contains(symptom))
                {
                    _prediction[item.Key]++;
                }
            }

            foreach (var predict in _prediction)
            {
                _prediction[item.Key] /= _db.Db[item.Key].Count;
            }
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
            else
            {
                return new Tuple<bool, string?>(false, null);
            }
        }

        return null;
    }

    private string NextQuestion()
    {
        
        foreach (var item in _db.Distribution)
        {
            if (_symptoms!.Contains(item.Key))
            {
                continue;
            }

            return item.Key;
        }

        return "";
    }
}
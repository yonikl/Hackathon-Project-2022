using SixLabors.ImageSharp.Processing;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;

namespace Data_Analysis;

public class Analysis
{
    private FromDb? _db;
    private List<string>? _symptoms;
    private IDictionary<string, double>? _prediction;
    private List<string>? _deniedSymptoms;

    public Analysis()
    {
        _deniedSymptoms = new List<string>();
        _db = new FromDb();
    }

    public Amswer MakeADecision()
    {
        double i = 1;
        foreach (var item in _prediction!)
        {

            foreach (var item2 in _prediction)
            {
                if (item2.Value >= i)
                {
                    return new Amswer(item2.Key,true);
                }
            }

            i -= 0.1;
            if (i == 0)
                break;
        }

        return null;
    }

    public Dictionary<string,double> probabilityOfDisease()
    {
        double i = 1;
        foreach (var item in _prediction!)
        {
           
            foreach (var item2 in _prediction)
            {
                if (item2.Value >= i)
                {
                    var x = new Dictionary<string, double>();
                    x.Add(item2.Key, item2.Value);
                    return x;
                }
            }
          
            i -= 0.1;
            if (i == 0)
                break;
        }

        return null;


    }

    public Amswer TryToDiagnose(List<string> symptoms)
    {
        
        this._symptoms = symptoms;

        foreach(var i in _symptoms)
        {
            if(!_deniedSymptoms!.Contains(i))
                _deniedSymptoms.Add(i.ToLower());
        }

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
            return NextQuestion();
        }

    }

    public void denideQ(string q)
    {
        _deniedSymptoms!.Add(q.ToLower());
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

    private Amswer NextQuestion()
    {

        if (_db!.DistributionPriority.Count == _deniedSymptoms!.Count)
            return MakeADecision();

        foreach (var item in _db!.DistributionPriority)
        {
            if (!_symptoms!.Contains(item) && !_deniedSymptoms!.Contains(item))
            {
                foreach (var i in _db.Db.Values)
                {
                    bool flag = true;
                    foreach (var j in _symptoms)
                    {
                        if (!i.Contains(j))
                            flag = false;
                    }
                    if (flag == true && i.Contains(item))
                        return new Amswer(item, false);
                }

            }

           
        }
        return MakeADecision();
    }
}
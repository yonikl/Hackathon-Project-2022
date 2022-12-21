using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace Data_Analysis;

public class FromDb
{
    public IDictionary<string, List<string>> Db { get; }
    public IDictionary<string,int[]?> Distribution { get; }
    public List<string> DistributionPriority { get; }

    public FromDb()
    {
        IDictionary<string, int[]?> Distribution = new Dictionary<string, int[]?>();
        
        string json = File.ReadAllText("C:\\Users\\Daniel\\source\\repos\\yonikl\\Hackathon-Project-2022\\Data Analysis\\xl.txt");
        Db = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json)!;
        foreach (var item in Db)
        {
            Console.WriteLine(item.Key);
            foreach (var i in item.Value)
            {
                if(Distribution.Keys.Contains(i))
                {
                    continue;
                }
                Distribution.Add(i,new int[]{0,0});
            }
        }

        foreach (var item in Distribution)
        {
            foreach (var i in Db)
            {
                if (i.Value.Contains(item.Key))
                {
                    item.Value![0]++;
                }
                else
                {
                    item.Value![1]++;
                }
            }
        }

    }

  
}
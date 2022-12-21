using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace Data_Analysis;

public class FromDb
{
    public IDictionary<string, List<string>> Db { get; }
    public IDictionary<string, int[]?> Distribution { get; }
    public List<string> DistributionPriority { get; }

    public FromDb()
    {
        Distribution = new Dictionary<string, int[]?>();
        DistributionPriority = new List<string>();
        run_cmd();
        string json = File.ReadAllText("C:\\Users\\Yoni\\RiderProjects\\Hackathon-Project-2022\\Hackathon-Project-2022\\Data Analysis\\xl.txt");
        json = json.ToLower();
        Db = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json)!;
        foreach (var item in Db)
        {

            foreach (var i in item.Value)
            {
                if (Distribution.Keys.Contains(i))
                {
                    continue;
                }
                Distribution.Add(i,new[]{0,0});
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

        DistributionPriority = SortPriority();
    }

    private void run_cmd()
    {

        string fileName =
            @"C:\Users\Yoni\RiderProjects\Hackathon-Project-2022\Hackathon-Project-2022\Data Analysis\ParseXlsx.py";

        Process p = new Process();
        p.StartInfo =
            new ProcessStartInfo(@"C:\Users\Yoni\AppData\Local\Programs\Python\Python310\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        p.Start();

        string output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        Console.WriteLine(output);
    }

    private List<string> SortPriority()
    {
        Dictionary<string, int[]?> dCopy = new Dictionary<string, int[]?>();
        foreach (var entry in Distribution)
        {
            dCopy.Add(entry.Key, (int[]?)entry.Value!.Clone());
        }
        string? high = dCopy.Keys.First();
        var temp = new List<string>();
        while(dCopy.Any())
        {
            foreach (var item in dCopy)
            {
                if (Priority(high) < Priority(item.Key))
                {
                    continue;
                }

                high = item.Key;
                
            }
            temp.Add(high!);
            dCopy.Remove(high!);
            if(!dCopy.Any())
                break;
            high = dCopy.Keys.First();
        }
        temp.Reverse();
        return temp;
    }

    private double Priority(string s){
    
        var a = Distribution[s];
        return Math.Abs(FindMin(a![0],a[1])/ FindMax(a![0],a[1]));
    }

    private static double FindMax(double a, double b)
    {
        return a > b ? a : b;
    }
    private static double FindMin(double a, double b)
    {
        return a < b ? a : b;
    }
    
}
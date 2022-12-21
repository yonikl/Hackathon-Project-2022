using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace Data_Analysis;

public class FromDb
{
    public IDictionary<string, List<string>> Db { get; }
    public IDictionary<string,int[]?> Distribution { get; }

    public FromDb()
    {
        IDictionary<string, int[]?> Distribution = new Dictionary<string, int[]?>();
        run_cmd();
        string json = File.ReadAllText("C:\\Users\\Yoni\\RiderProjects\\Hackathon-Project-2022\\Hackathon-Project-2022\\Data Analysis\\xl.txt");
        Db = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json)!;
        foreach (var item in Db)
        {
            Console.WriteLine(item.Key);
            foreach (var i in item.Value)
            {
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
}
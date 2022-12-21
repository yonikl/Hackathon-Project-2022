using Excel = Microsoft.Office.Interop.Excel;

namespace Data_Analysis;

public class FromDb
{
    public IDictionary<string, List<string>> Db { get; }
    public IDictionary<string,int[]> Distribution
    {
        get;
    }
    public FromDb()
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"sandbox_test.xlsx");
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;
        IDictionary<string, List<string>> db = new Dictionary<string, List<string>>();

    }
}
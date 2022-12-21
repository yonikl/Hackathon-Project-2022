namespace Data_Analysis;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
public class FromDb
{
    public IDictionary<string, List<string>> db { get; }
    public FromDb()
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        wb = excel.Worksheets.open(path);
        ws = wb.Worksheets[Sheet];
        IDictionary<string, List<string>> db = new Dictionary<string, List<string>>();
        
    }
}
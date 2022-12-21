// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Data_Analysis;

var l = new List<string>();
// l.Add("paleness and sweating");
l.Add("general weakness");
l.Add("feel the heartbeat");
l.Add("difficulty breathing");
Analysis a = new Analysis();
var b = a.TryToDiagnose(l);
Console.WriteLine(b.IsFinalAnswer + "     " + b.Question);
// a.TryToDiagnose(["li"])
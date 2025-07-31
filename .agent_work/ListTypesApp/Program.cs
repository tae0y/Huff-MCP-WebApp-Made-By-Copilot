using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        var assembly = Assembly.LoadFrom("/Users/bachtaeyeong/.nuget/packages/modelcontextprotocol/0.3.0-preview.3/lib/net9.0/ModelContextProtocol.dll");
        foreach (var type in assembly.GetExportedTypes())
        {
            Console.WriteLine(type.FullName);
        }
    }
}

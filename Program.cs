using System;
using System.Management;

namespace ComPortViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort"))
            {
                var ports = searcher.Get();
                bool first = true;
                foreach (var portObj in ports)
                {
                    if(!first)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    var props = portObj.Properties;
                    Console.WriteLine("Begin Object: " + props["DeviceID"].Value);
                    Console.WriteLine("----------------------------------");
                    foreach (var prop in props)
                    {
                        Console.WriteLine(prop.Name + " - " + prop.Value);
                    }
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("End Object: " + props["DeviceID"].Value);
                    if (first) first = false;
                }
            }
        }
    }
}

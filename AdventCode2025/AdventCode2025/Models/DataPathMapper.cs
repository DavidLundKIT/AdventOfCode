using System.Diagnostics;

namespace AdventCode2025.Models;

public class DataPathMapper
{
    public Dictionary<string, List<string>> DeviceOutputs { get; set; }

    public DataPathMapper(string[] lines)
    {
        DeviceOutputs = new Dictionary<string, List<string>>();
        foreach (var line in lines)
        {
            var parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var device = parts[0];
            var outputs = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            DeviceOutputs.Add(device, outputs);
        }
    }

    public long CountAllDataPathsFromDevice(string device)
    {
        if (!DeviceOutputs.ContainsKey(device))
        {
            return 0;
        }
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        if (outputs.Count == 1 && string.Equals(outputs[0], "out"))
        {
            return 1;
        }
        foreach (var output in outputs)
        {
            totalPaths += CountAllDataPathsFromDevice(output);
        }
        return totalPaths;
    }

    public long CountAllDataPathsFromDevice(string device, string endDevice)
    {
        if (!DeviceOutputs.ContainsKey(device))
        {
            return 0;
        }
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        if (string.Equals(outputs[0], endDevice))
        {
            return 1;
        }
        foreach (var output in outputs)
        {
            totalPaths += CountAllDataPathsFromDevice(output, endDevice);
        }
        return totalPaths;
    }

    public long CountAllDataPathsFromDevice(string device, string endDevice, HashSet<string> visited)
    {
        Debug.WriteLine("Device: {0}, end: {1}", device, endDevice);
        if (string.Equals(device, endDevice))
        {
            return 1;
        }
        if (string.Equals("out", device))
        {
            if (string.Equals("out", endDevice))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        if (!DeviceOutputs.ContainsKey(device))
        {
            return 0;
        }
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        if (string.Equals(outputs[0], endDevice))
        {
            return 1;
        }

        if (visited.Contains(device))
        {
            return 0;
        }
        var nv = new HashSet<string>(visited);
        nv.Add(device);
        foreach (var output in outputs)
        {
            totalPaths += CountAllDataPathsFromDevice(output, endDevice, nv);
        }
        return totalPaths;
    }

    public long CountPathsViaDacFftFromDevice(string device, bool foundDac, bool foundFft, string dataPath)
    {
        if (!DeviceOutputs.ContainsKey(device))
        {
            Console.WriteLine("Missing key: {0}", device);
            return 0;
        }

        List<string> devices;
        if (!string.IsNullOrWhiteSpace(dataPath))
        {
            devices = dataPath.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (devices.Contains(device))
            {
                // been here before, devices 
                Console.WriteLine("Contains key: {0}", device);
                return 0;
            }
        }
        else
        {
            devices = new List<string>();
        }
        devices.Add(device);
        var newDataPath = string.Join(',', devices);
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        if (outputs.Count == 1 && string.Equals(outputs[0], "out"))
        {
            if (foundDac && foundFft)
            {
                Console.WriteLine("Found path");
                return 1;
            }
            Console.WriteLine("Out but not via dac and fft");
            return 0;
        }
        if (string.Equals(device, "dac"))
            foundDac = true;
        if (string.Equals(device, "fft"))
            foundFft = true;
        foreach (var output in outputs)
        {
            totalPaths += CountPathsViaDacFftFromDevice(output, foundDac, foundFft, newDataPath);
        }
        if (totalPaths > 0)
        {
            Console.WriteLine("Total paths: {0}", totalPaths);
        }
        return totalPaths;
    }
}

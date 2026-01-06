using System.Diagnostics;

namespace AdventCode2025.Models;

public record DataPathKey(string FromDevice, string ToDevice);

/// <summary>
/// The soulution to Day 11 part 2 comes from looking at Andreas' solution.
/// He cached the intermediate results to avoid re-computation. 
/// I have actually done this in a previous year and forgot it.
/// My hashedSet approach probably would work but it would take forever!
/// It had no solutions after 22 hours of running.
/// </summary>
public class DataPathMapper
{
    public Dictionary<string, List<string>> DeviceOutputs { get; set; }
    public Dictionary<DataPathKey, long> PathCache { get; set; }

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
        PathCache = new Dictionary<DataPathKey, long>();
    }

    public long CountAllDataPathsFromDevice(string device, string endDevice)
    {
        if (string.Equals(device, endDevice))
        {
            return 1;
        }
        var key = new DataPathKey(device, endDevice);
        if (PathCache.ContainsKey(key))
        {
            return PathCache[key];
        }
        if (!DeviceOutputs.ContainsKey(device))
        {
            return 0;
        }
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        foreach (var output in outputs)
        {
            totalPaths += CountAllDataPathsFromDevice(output, endDevice);
        }
        PathCache.Add(key, totalPaths);
        return totalPaths;
    }
}

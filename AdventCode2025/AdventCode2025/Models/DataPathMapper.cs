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

    public long CountPathsViaDacFftFromDevice(string device, bool foundDac, bool foundFft)
    {
        if (!DeviceOutputs.ContainsKey(device))
        {
            return 0;
        }
        long totalPaths = 0;
        var outputs = DeviceOutputs[device];
        if (outputs.Count == 1 && string.Equals(outputs[0], "out"))
        {
            if (foundDac && foundFft)
                return 1;
            return 0;
        }
        if (string.Equals(device, "dac"))
            foundDac = true;
        if (string.Equals(device, "fft"))
            foundFft = true;
        foreach (var output in outputs)
        {
            totalPaths += CountPathsViaDacFftFromDevice(output, foundDac, foundFft);
        }
        return totalPaths;
    }
}

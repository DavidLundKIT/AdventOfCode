namespace AdventCode2023.Models
{
    public enum InDataSection
    {
        Seeds,
        SeedSoil,
        SoilFertilizer,
        FertilizerWater,
        WaterLight,
        LightTemperature,
        TemperatureHumidity,
        HumidityLocation,
        Done
    }
    public class SeedFertilizerMapper
    {
        public List<long> Seeds { get; set; }
        public SortedList<long, SourceDestionationMapper> SeedSoil { get; set; }
        public SortedList<long, SourceDestionationMapper> SoilFertilizer { get; set; }
        public SortedList<long, SourceDestionationMapper> FertilizerWater { get; set; }
        public SortedList<long, SourceDestionationMapper> WaterLight { get; set; }
        public SortedList<long, SourceDestionationMapper> LightTemperature { get; set; }
        public SortedList<long, SourceDestionationMapper> TemperatureHumidity { get; set; }
        public SortedList<long, SourceDestionationMapper> HumidityLocation { get; set; }


        public SeedFertilizerMapper()
        {
            Seeds = new List<long>();
            SeedSoil = new SortedList<long, SourceDestionationMapper>();
            SoilFertilizer = new SortedList<long, SourceDestionationMapper>();
            FertilizerWater = new SortedList<long, SourceDestionationMapper>();
            WaterLight = new SortedList<long, SourceDestionationMapper>();
            LightTemperature = new SortedList<long, SourceDestionationMapper>();
            TemperatureHumidity = new SortedList<long, SourceDestionationMapper>();
            HumidityLocation = new SortedList<long, SourceDestionationMapper>();
        }

        public void ParseData(string[] lines)
        {
            SourceDestionationMapper map;
            InDataSection mode = InDataSection.Seeds;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    mode = ChangeParseMode(mode);
                    continue;
                }
                switch (mode)
                {
                    case InDataSection.Seeds:
                        var temp = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                        Seeds.AddRange(temp[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(n => long.Parse(n)));
                        break;
                    case InDataSection.SeedSoil:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            SeedSoil.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.SoilFertilizer:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            SoilFertilizer.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.FertilizerWater:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            FertilizerWater.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.WaterLight:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            WaterLight.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.LightTemperature:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            LightTemperature.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.TemperatureHumidity:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            TemperatureHumidity.Add(map.Source, map);
                        }
                        break;
                    case InDataSection.HumidityLocation:
                        if (char.IsDigit(line[0]))
                        {
                            map = new SourceDestionationMapper(line);
                            HumidityLocation.Add(map.Source, map);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public long MapToDestination(long source, SortedList<long, SourceDestionationMapper> maps)
        {
            foreach (var map in maps)
            {
                if (source < map.Key)
                {
                    return source;
                }
                if (map.Key <= source && source <= map.Key + map.Value.Range - 1)
                {
                    // in the range
                    return (source - map.Value.Source) + map.Value.Destination;
                }
            }
            // no match so to itself
            return source;
        }

        public long FromSeedToLocation(long seed)
        {
            long soil = MapToDestination(seed, SeedSoil);
            long fert = MapToDestination(soil, SoilFertilizer);
            long water = MapToDestination(fert, FertilizerWater);
            long light = MapToDestination(water, WaterLight);
            long temp = MapToDestination(light, LightTemperature);
            long humid = MapToDestination(temp, TemperatureHumidity);
            long location = MapToDestination(humid, HumidityLocation);
            return location;
        }

        public long FindNearestSeedLocation()
        {
            long nearest = long.MaxValue;

            foreach (var seed in Seeds)
            {
                long location = FromSeedToLocation(seed);
                nearest = location < nearest ? location : nearest;
            }
            return nearest;
        }

        public long FindNearestSeedRangesLocation()
        {
            long nearest = long.MaxValue;

            //foreach (var seed in Seeds)
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                for (long seed = Seeds[i]; seed < Seeds[i] + Seeds[i + 1]; ++seed)
                {
                    long location = FromSeedToLocation(seed);
                    nearest = location < nearest ? location : nearest;
                }
            }
            return nearest;
        }

        public InDataSection ChangeParseMode(InDataSection modeNow)
        {
            switch (modeNow)
            {
                case InDataSection.Seeds:
                    return InDataSection.SeedSoil;
                case InDataSection.SeedSoil:
                    return InDataSection.SoilFertilizer;
                case InDataSection.SoilFertilizer:
                    return InDataSection.FertilizerWater;
                case InDataSection.FertilizerWater:
                    return InDataSection.WaterLight;
                case InDataSection.WaterLight:
                    return InDataSection.LightTemperature;
                case InDataSection.LightTemperature:
                    return InDataSection.TemperatureHumidity;
                case InDataSection.TemperatureHumidity:
                    return InDataSection.HumidityLocation;
                case InDataSection.HumidityLocation:
                    return InDataSection.Done;
                default:
                    throw new ArgumentOutOfRangeException("huh? modeNow");
            }
        }


    }

    public class SourceDestionationMapper
    {
        public long Destination { get; set; }
        public long Source { get; set; }
        public long Range { get; set; }

        public SourceDestionationMapper(string line)
        {
            var temp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Destination = long.Parse(temp[0]);
            Source = long.Parse(temp[1]);
            Range = long.Parse(temp[2]);
        }
    }

}

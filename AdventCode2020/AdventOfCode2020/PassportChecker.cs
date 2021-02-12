using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class PassportChecker
    {
        public string[] Lines { get; set; }
        public Dictionary<string, string> Fields { get; set; }
        public bool Invalid { get; set; }

        /*
            byr (Birth Year)
            iyr (Issue Year)
            eyr (Expiration Year)
            hgt (Height)
            hcl (Hair Color)
            ecl (Eye Color)
            pid (Passport ID)
            cid (Country ID)
        */
        private string[] requiredFields = new string[] {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

        private List<string> eyeColor = new List<string>() {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        public PassportChecker()
        {
            Fields = new Dictionary<string, string>();
        }

        public void Clear()
        {
            Fields.Clear();
            Invalid = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns>
        ///     true if parsed data
        ///     false if empty line
        /// </returns>
        public bool AddLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }
            var fields = line.Split(new char[] { ' ' });
            foreach (var item in fields)
            {
                var kvArr = item.Split(new char[] { ':' });
                if (!Fields.TryAdd(kvArr[0], kvArr[1]))
                {
                    Invalid = true;
                }
            }
            return true;
        }
        public bool IsValid()
        {
            if (Invalid)
                return false;

            foreach (var reqField in requiredFields)
            {
                if (!Fields.ContainsKey(reqField))
                    return false;
            }
            // country check if we cared
            return true;
        }

        public bool IsValidAdvanced()
        {
            if (Invalid)
                return false;

            foreach (var reqField in requiredFields)
            {
                if (!Fields.ContainsKey(reqField))
                    return false;
                if (!validateField(reqField, Fields[reqField]))
                {
                    return false;
                }
            }
            // country check if we cared
            return true;
        }

        public int ProcessPassports(string[] lines, bool useValidation)
        {
            Clear();
            int validPassports = 0;

            foreach (var line in lines)
            {
                if (!AddLine(line))
                {
                    // empty line check passport
                    if (useValidation)
                    {
                        if (IsValidAdvanced())
                            validPassports++;
                    }
                    else
                    {
                        if (IsValid())
                            validPassports++;
                    }
                    Clear();
                }
            }

            if (Fields.Count > 0)
            {
                if (useValidation)
                {
                    if (IsValidAdvanced())
                        validPassports++;
                }
                else
                {
                    if (IsValid())
                        validPassports++;
                }
                Clear();
            }

            return validPassports;
        }

        public bool validateField(string key, string value)
        {
            bool valid = false;
            switch (key)
            {
                case "byr":
                    if (int.TryParse(value, out int byr))
                    {
                        valid = (1920 <= byr && byr <= 2002);
                    }
                    break;
                case "iyr":
                    if (int.TryParse(value, out int iyr))
                    {
                        valid = (2010 <= iyr && iyr <= 2020);
                    }
                    break;
                case "eyr":
                    if (int.TryParse(value, out int eyr))
                    {
                        valid = (2020 <= eyr && eyr <= 2030);
                    }
                    break;
                case "hgt":
                    int hgt = 0;
                    if (value.Contains("in"))
                    {
                        hgt = int.Parse(value.Replace("in", ""));
                        valid = (59 <= hgt && hgt <= 76);
                    }
                    else if (value.Contains("cm"))
                    {
                        hgt = int.Parse(value.Replace("cm", ""));
                        valid = (150 <= hgt && hgt <= 193);
                    }
                    else
                    {
                        valid = false;
                    }
                    break;
                case "hcl":
                    Regex rgx = new Regex(@"^#[0-9a-f]{6}$");
                    valid = rgx.IsMatch(value);
                    break;
                case "ecl":
                    valid = eyeColor.Contains(value);
                    break;
                case "pid":
                    Regex rgx2 = new Regex(@"^\d{9}$");
                    valid = rgx2.IsMatch(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"key is {key}");
            }
            return valid;
        }
    }
}

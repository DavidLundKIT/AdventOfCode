using System;

namespace AdventCodeLib
{
    public class Day09GroupGarbage
    {

        public string ReadData(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            if (rows.Length > 1)
            {
                throw new Exception("Huh!");
            }

            return rows[0];
        }

        public int GroupCount(string s, out int score, out int junkChars)
        {
            int count = 0;
            junkChars = 0;
            score = 0;
            int flag = 0;
            bool inJunk = false;
            var chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '!')
                {
                    // skip next char
                    i++;
                    continue;
                }

                if(inJunk && chars[i] == '>')
                {
                    inJunk = false;
                    continue;
                }

                if (!inJunk && chars[i] == '<')
                {
                    inJunk = true;
                    continue;
                }

                if (!inJunk && chars[i] == '{')
                {
                    flag++;
                }

                if (!inJunk && chars[i] == '}')
                {
                    count++;
                    score += flag;
                    flag--;
                }

                if (inJunk)
                {
                    junkChars++;
                }
            }
            return count;
        }
    }
}

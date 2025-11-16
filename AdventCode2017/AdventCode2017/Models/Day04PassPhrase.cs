using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class Day04PassPhrase
    {
        public Day04PassPhrase()
        {

        }

        public bool CheckPassPhrase(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                return false;
            }

            var words = phrase.Split(null);
            
            Dictionary<string, string> uniqueWords = new Dictionary<string, string>();
            foreach (var word in words)
            {
                if (!uniqueWords.ContainsKey(word))
                {
                    uniqueWords.Add(word, word);
                }
                else
                {
                    // has this word!
                    return false;
                }
            }
            return true;
        }

        public bool CheckPassPhraseAnagrams(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                return false;
            }

            var words = phrase.Split(null);

            Dictionary<string, string> uniqueWords = new Dictionary<string, string>();
            foreach (var word in words)
            {
                var chars = word.ToCharArray().ToList();
                chars.Sort();
                string key = string.Join("", chars);

                if (!uniqueWords.ContainsKey(key))
                {
                    uniqueWords.Add(key, word);
                }
                else
                {
                    // has this word!
                    return false;
                }
            }
            return true;
        }

        public int NumberValidPassPhrasesInFile(string path)
        {
            var phrases = DataTools.ReadAllLines(path);

            int validCount = 0;

            foreach (var phrase in phrases)
            {
                if(CheckPassPhrase(phrase))
                {
                    validCount++;
                }
            }

            return validCount;
        }

        public int NumberValidPassPhrasesInFile2(string path)
        {
            var phrases = DataTools.ReadAllLines(path);

            int validCount = 0;

            foreach (var phrase in phrases)
            {
                if (CheckPassPhraseAnagrams(phrase))
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}

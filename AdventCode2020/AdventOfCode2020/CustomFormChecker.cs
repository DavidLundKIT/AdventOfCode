using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class CustomFormChecker
    {
        public Dictionary<char, int> Questions { get; set; }
        public int PeopleInGroup { get; set; }

        public CustomFormChecker()
        {
            Questions = new Dictionary<char, int>();
        }

        public void Clear()
        {
            Questions.Clear();
            PeopleInGroup = 0;
        }

        public bool AddPerson(string form)
        {
            if (string.IsNullOrWhiteSpace(form))
                return false;
            PeopleInGroup += 1;
            var questions = form.ToCharArray();
            foreach (var q in questions)
            {
                if (Questions.ContainsKey(q))
                {
                    Questions[q] += 1;
                }
                else
                {
                    Questions.Add(q, 1);
                }

            }
            return true;
        }

        public int ProcessForms(string[] forms)
        {
            Clear();
            int sum = 0;
            foreach (var form in forms)
            {
                if (!AddPerson(form))
                {
                    // done with group
                    sum += Questions.Count;
                    Clear();
                }
            }
            if (Questions.Count > 0)
            {
                sum += Questions.Count;
                Clear();
            }
            return sum;
        }

        public int CountQuestionsEveryoneAnswered()
        {
            int count = 0;
            foreach (var item in Questions)
            {
                if (item.Value == PeopleInGroup)
                    count++;
            }
            return count;
        }

        public int ProcessFormsAdvanced(string[] forms)
        {
            Clear();
            int sum = 0;
            foreach (var form in forms)
            {
                if (!AddPerson(form))
                {
                    // done with group
                    sum += CountQuestionsEveryoneAnswered();
                    Clear();
                }
            }
            if (Questions.Count > 0)
            {
                sum += CountQuestionsEveryoneAnswered();
                Clear();
            }
            return sum;
        }
    }
}

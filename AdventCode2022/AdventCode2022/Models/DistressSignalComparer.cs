using System.Text.Json.Nodes;

namespace AdventCode2022.Models
{
    public class DistressSignalComparer
    {

        public int Compare(string left, string right)
        {
            var leftJson = JsonNode.Parse(left);
            var rightJson = JsonNode.Parse(right);

            return Compare(leftJson, rightJson);
        }

        public int Compare(JsonNode left, JsonNode right)
        {
            if (left is JsonValue && right is JsonValue)
            {
                return (int)left - (int)right;
            }
            JsonArray arrayLeft = left as JsonArray;
            if (arrayLeft == null)
            {
                arrayLeft = new JsonArray((int)left);
            }
            JsonArray arrayRight = right as JsonArray;
            if (arrayRight == null)
            {
                arrayRight = new JsonArray((int)right);
            }
            return arrayLeft.Zip(arrayRight).Select(p => Compare(p.First, p.Second)).FirstOrDefault(c => c != 0, arrayLeft.Count - arrayRight.Count);
        }
    }
}

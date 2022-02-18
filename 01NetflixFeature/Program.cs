using System.Text;

//Netflix Feature 01: Group Similar Titles

class Program
{
    public static List<List<string>> GroupTitles(string[] strs)
    {
        if (strs.Length == 0) return new List<List<string>>();

        // Key:Value Pair
        Dictionary<string, List<string>> res = new();

        // initialize int[] count of 26 elements (meant to store the 26 letters of the Alphabet)
        int[] count = new int[26];

        // iterate through GroupTitles(string[] strs) "key"
        foreach(var s in strs)
        {
            // create new count array per value
            count = new int[26];

            // foreach value (letter) in key (word) that is converted to a char array
            foreach(var c in s.ToCharArray())
            {
                int index = c - 'a';    // value - char value = 0
                count[index]++;         // (example 100'd' now = 0 + 3 as d is the 4th letter in the alphabet)
            }

            // Creates a string of #0 or #(how many letters in a word this contains)(a-z)
            StringBuilder delimStr = new("");   
            for (int i = 0; i < 26; i++)
            {
                delimStr.Append('#');
                delimStr.Append(count[i]);
            }

            // Adds each #0#0... key to a string then counts the same string and places them together in a list of list res[key].Add(s)
            string key = delimStr.ToString();
            if (!res.ContainsKey(key)) res[key] = new List<string>();   // not the same key? create new list

            res[key].Add(s);
        }

        return new List<List<string>>(res.Values.ToList()); // Selects key then value in Dictionary < TKey, TValue > and adds it to list. Kind of like Key.Value.ToList(); However, res is a string of likeness with #0#0...
    }

    public static void Main(string[] args)
    {
        // Driver Code
        string[] titles = { "duel", "dule", "speed", "spede", "deul", "cars", "casr" };

        List<List<string>> gt = GroupTitles(titles);
        string speed = "speed";
        string duel = "duel";
        string cars = "cars";

        // Searching for All Titles
        foreach(List<string> g in gt)
        {
            if (g.Contains(speed)) Console.WriteLine("[{0}]", string.Join(", ", g));
            if (g.Contains(duel)) Console.WriteLine("[{0}]", string.Join(", ", g));
            if (g.Contains(cars)) Console.WriteLine("[{0}]", string.Join(", ", g));
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//Netflix Feature 01: Group Similar Titles

class Program
{
    public static List<List<string>> GroupTitles(string[] strs)
    {
        if (strs.Length == 0) return new List<List<string>>();

        //Key:Value Pair
        Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();

        int[] count = new int[26];
        foreach(var s in strs)
        {
            count = new int[26];
            foreach(var c in s.ToCharArray())
            {
                int index = c - 'a';
                count[index]++;
            }

            StringBuilder delimStr = new StringBuilder("");
            for (int i = 0; i < 26; i++)
            {
                delimStr.Append('#');
                delimStr.Append(count[i]);
            }

            string key = delimStr.ToString();
            if (!res.ContainsKey(key)) res[key] = new List<string>();

            res[key].Add(s);
        }

        return new List<List<string>>(res.Values.ToList());
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
using System;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if(strs == null || strs.Length == 0)
            return "";

        string prefix = strs[0];

        for (int i=1 ; i<strs.Length ; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix == "")
                    return "";
            }
        }

        return prefix;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        System.Console.WriteLine(solution.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
        System.Console.WriteLine(solution.LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
    }
}
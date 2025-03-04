using System;

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        System.Console.WriteLine(solution.StrStr("sadbutsad", "sad"));
        System.Console.WriteLine(solution.StrStr("leetcode", "leeto"));
    }
}
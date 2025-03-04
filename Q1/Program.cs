using System;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        string[] words = s.Trim().Split(' ');
        return words[words.Length - 1].Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Example test cases
        Console.WriteLine(solution.LengthOfLastWord("Hello World")); // Output: 5
        Console.WriteLine(solution.LengthOfLastWord("   fly me   to   the moon  ")); // Output: 4
        Console.WriteLine(solution.LengthOfLastWord("luffy is still joyboy")); // Output: 6
    }
}
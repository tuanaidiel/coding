using System;

class Program
{
    static void triangle(int n)
    {
        for (int i=1 ; i<=n ; i++)
        {
            System.Console.WriteLine(new string ('*',i));
        }
        
    }

    static void Main(string[] args)
    {
        triangle(5);
    }
}
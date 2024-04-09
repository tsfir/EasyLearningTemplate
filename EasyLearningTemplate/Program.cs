using System;

public class Program
{
    [assembly: InternalsVisibleTo("CourseTask.Tests")]
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
    }
}
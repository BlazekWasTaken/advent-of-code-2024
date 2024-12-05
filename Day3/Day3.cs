using System.Text.RegularExpressions;

namespace Day3;

public class Day3
{
    private readonly string _memory = File.ReadAllText("memory.txt");
    
    public int Part1()
    {
        var multiplications = 0;
        var matches = 
            Regex.Matches(_memory, @"mul\([0-9]+,[0-9]+\)").Select(m => m.Value).ToList();
        foreach (var match in matches)
        {
            var num1 = int.Parse(match.Split(",")[0].Split("(")[1]);
            var num2 = int.Parse(match.Split(",")[1].Split(")")[0]);
            multiplications += num1 * num2;
        }
        return multiplications;
    }
    
    public int Part2()
    {
        var multiplications = 0;
        var dos = _memory.Split("do()");
        foreach (var segment in dos)
        {
            var donts = segment.Split("don't()");
            for (int j = 0; j < donts.Length; j++)
            {
                if (j != 0) continue;
                var matches = 
                    Regex.Matches(donts[j], @"mul\([0-9]+,[0-9]+\)").Select(m => m.Value).ToList();
                foreach (var match in matches)
                {
                    var num1 = int.Parse(match.Split(",")[0].Split("(")[1]);
                    var num2 = int.Parse(match.Split(",")[1].Split(")")[0]);
                    multiplications += num1 * num2;
                }
            }
        }
        return multiplications;
    }
}
namespace Day1;

public class Day1
{
    private readonly List<int> _list1 = [];
    private readonly List<int> _list2 = [];
    
    public Day1()
    {
        var file = File.ReadAllLines("lists.txt");
        foreach (var line in file)
        {
            var split = line.Split(" ");
            try
            {
                _list1.Add(int.Parse(split.First()));
                _list2.Add(int.Parse(split.Last()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    
    public int Part1()
    {
        var distances = new List<int>();
        var list1 = _list1.ToList();
        var list2 = _list2.ToList();

        while (list1.Count > 0 && list2.Count > 0)
        {
            var smallest1 = list1.Min();
            var smallest2 = list2.Min();
            distances.Add(Math.Abs(smallest1 - smallest2));
            list1.Remove(smallest1);
            list2.Remove(smallest2);
        }
        
        return distances.Sum(x => x);
    }
    
    public int Part2()
    {
        return _list1.Sum(number => number * _list2.FindAll(x => x == number).Count);
    }
}
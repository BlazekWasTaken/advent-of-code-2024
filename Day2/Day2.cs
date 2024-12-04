namespace Day2;

public class Day2
{
    private List<List<int>> _list = [];
    
    public Day2()
    {
        var file = File.ReadAllLines("reports.txt");
        foreach (var line in file)
        {
            var split = line.Split(" ");
            try
            {
                _list.Add(split.Select(int.Parse).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    
    public int Part1()
    {
        return _list.Where(row => row[0] != row[1]).Count(IsRowCorrect);
    }

    public int Part2()
    {
        return _list.Count(row =>
        {
            if (IsRowCorrect(row)) return true;
            var i = 0;
            while (i != row.Count)
            {
                var newRow = row.ToList();
                newRow.RemoveAt(i);
                if (IsRowCorrect(newRow)) return true;
                i++;
            }
            return false;
        });
    }

    private static bool IsRowCorrect(List<int> row)
    {
        var isIncreasing = row[0] <= row[1] ? 1 : -1;
        for (var i = 0; i < row.Count - 1; i++)
        {
            var diff = (row[i + 1] - row[i]) * isIncreasing;
            if (diff is < 1 or > 3) return false;
        }
        return true;
    }
}
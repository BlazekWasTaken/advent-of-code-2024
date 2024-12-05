using System.Text.RegularExpressions;

namespace Day4;

public class Day4
{
    private List<List<char>> _list = [];
    
    public Day4()
    {
        var file = File.ReadAllLines("xmas.txt");
        foreach (var line in file)
        {
            _list.Add(line.ToList());
        }
    }
    
    public int Part1()
    {
        var xmasCount = 0;
        foreach (var line in _list)
        {
            xmasCount += Regex.Matches(new string(line.ToArray()), "XMAS").Count;
            xmasCount += Regex.Matches(new string(line.ToArray()), "SAMX").Count;
        }
        foreach (var line in _list.GetColumns())
        {
            xmasCount += Regex.Matches(new string(line.ToArray()), "XMAS").Count;
            xmasCount += Regex.Matches(new string(line.ToArray()), "SAMX").Count;
        }
        foreach (var line in _list.GetPrincipalDiagonalLines())
        {
            xmasCount += Regex.Matches(new string(line.ToArray()), "XMAS").Count;
            xmasCount += Regex.Matches(new string(line.ToArray()), "SAMX").Count;
        }
        foreach (var line in _list.GetSecondaryDiagonalLines())
        {
            xmasCount += Regex.Matches(new string(line.ToArray()), "XMAS").Count;
            xmasCount += Regex.Matches(new string(line.ToArray()), "SAMX").Count;
        }
        return xmasCount;
    }

    public int Part2()
    {
        var xmasCount = 0;
        for (int i = 1; i < _list.Count - 1; i++)
        {
            for (int j = 1; j < _list[i].Count - 1; j++)
            {
                if (_list[i][j] != 'A') continue;

                var principalDiagonal = new string(new List<char>
                {
                    _list[i - 1][j - 1],
                    _list[i][j],
                    _list[i + 1][j + 1]
                }.ToArray());

                var secondaryDiagonal = new string(new List<char>
                {
                    _list[i - 1][j + 1],
                    _list[i][j],
                    _list[i + 1][j - 1]
                }.ToArray());

                if (principalDiagonal is not ("MAS" or "SAM")) continue;
                if (secondaryDiagonal is not ("MAS" or "SAM")) continue;
                xmasCount++;
            }
        }

        return xmasCount;
    }
}

internal static class Extensions
{
    public static List<List<T>> GetColumns<T>(this List<List<T>> list)
    {
        var columns = new List<List<T>>();
        for (var i = 0; i < list[0].Count; i++)
        {
            var column = list.Select(t => t[i]).ToList();
            columns.Add(column);
        }
        return columns;
    }
    
    public static List<List<T>> GetPrincipalDiagonalLines<T>(this List<List<T>> list)
    {
        var height = list.Count;
        var width = list[0].Count;
        
        var diagonals = new List<List<T>>();
        for (int i = -width; i < height; i++)
        {
            var diagonal = new List<T>();
            for (int j = 0; j < width; j++)
            {
                if (i + j < 0 || i + j >= height) continue;
                diagonal.Add(list[i + j][j]);
            }
            diagonals.Add(diagonal);
        }
        return diagonals;
    }

    public static List<List<T>> GetSecondaryDiagonalLines<T>(this List<List<T>> list)
    {
        var height = list.Count;
        var width = list[0].Count;
        
        var diagonals = new List<List<T>>();
        for (int i = -width; i < height; i++)
        {
            var diagonal = new List<T>();
            for (int j = 0; j < width; j++)
            {
                if (i + j < 0 || i + j >= height) continue;
                diagonal.Add(list[i + j][width - j - 1]);
            }
            diagonals.Add(diagonal);
        }

        return diagonals;
    }
}
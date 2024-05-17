using System.Diagnostics;

namespace Fire_Emblem;

public class Team
{
    public string PlayerName;
    public List<Unit> Units;

    public Team(string playerName, string[] teamLines, List<Character> characters)
    {
        PlayerName = playerName;
        Units = new List<Unit>();
        ConstructTeamFromFileLines(teamLines, characters);
    }
    
    private void ConstructTeamFromFileLines(string[] teamLines, List<Character> characters)
    {
        foreach (var line in teamLines)
        {
            Units.Add(new UnitConstructorFromLine(line, characters).CreateUnitFromLine());
        }
    }
}
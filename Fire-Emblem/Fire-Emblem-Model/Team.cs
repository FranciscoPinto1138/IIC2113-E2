using System.Diagnostics;

namespace Fire_Emblem;

public class Team
{
    public string PlayerName;
    public UnitList Units;

    public Team(string playerName, string[] teamLines, CharacterList characters)
    {
        PlayerName = playerName;
        Units = new UnitList();
        ConstructTeamFromFileLines(teamLines, characters);
    }
    
    private void ConstructTeamFromFileLines(string[] teamLines, CharacterList characters)
    {
        foreach (var line in teamLines)
        {
            Units.Add(new UnitConstructorFromLine(line, characters).CreateUnitFromLine());
        }
    }
}
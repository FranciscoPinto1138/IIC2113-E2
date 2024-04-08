using System.Diagnostics;

namespace Fire_Emblem;

public class Team
{
    public string PlayerName { get; }
    public List<Unit> Units { get; set;}

    public Team(string playerName)
    {
        PlayerName = playerName;
        Units = new List<Unit>();
    }

    public void ConstructTeamFromFileLines(string[] teamLines, List<Character> characters)
    {
        foreach (var line in teamLines)
        {
            Units.Add(CreateUnitFromLine(line, characters));
        }
    }
    
    public Unit CreateUnitFromLine(string line, List<Character> characters)
    {
        string[] parts = line.Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);
        string unitName = parts[0].Trim();
        string[] skills = parts.Length > 1 ? parts[1].Replace(")", "").Split(',') : Array.Empty<string>();
        Character character = characters.FirstOrDefault(c => c.Name.Trim() == unitName.Trim());
        return new Unit(
            character.Name,
            character.Weapon,
            character.Gender,
            character.DeathQuote,
            skills.Select(s => s.Trim()).ToArray(), // Trim each skill
            Convert.ToInt32(character.HP),
            Convert.ToInt32(character.Atk),
            Convert.ToInt32(character.Spd),
            Convert.ToInt32(character.Def),
            Convert.ToInt32(character.Res)
        );
    }

    public void RemoveDeadUnits()
    {
        Units.RemoveAll(unit => unit.HPCurrent <= 0);
    }
}
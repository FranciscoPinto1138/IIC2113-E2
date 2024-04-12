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
    
    private Unit CreateUnitFromLine(string line, List<Character> characters)
    {
        string[] partsUnitLine = line.Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);
        string unitName = partsUnitLine[0].Trim();
        string[] skills = partsUnitLine.Length > 1 ? partsUnitLine[1].Replace(")", "").Split(',') : Array.Empty<string>();
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

    public void RemoveDeadUnits(Unit unitPostCombat)
    {
        const int minimumHPofUnit = 0;
        if (unitPostCombat.HPCurrent <= minimumHPofUnit)
        {
            Units.Remove(unitPostCombat);
        }
    }

    public bool HasEqualUnits()
    {
        const int allowedNumberOfEqualUnits = 1;
        return Units.GroupBy(u => u.Name)
            .Any(g => g.Count() > allowedNumberOfEqualUnits);
    }
    
    
    public bool TeamHasValidSkills()
    {
        foreach (var unit in Units)
        {
            if (!unit.UnitHasValidAmountOfSkills())
            {
                return false;
            }

            if (unit.UnitHasEqualSkills())
            {
                return false;
            }
        }

        return true;
    }
    
    public bool HasValidLength()
    {
        const int maxUnitsPerTeam = 3;
        const int minUnitsPerTeam = 1;
        return (Units.Count <= maxUnitsPerTeam && Units.Count >= minUnitsPerTeam);
    }
}
using System.Diagnostics;

namespace Fire_Emblem;

public class Team
{
    private string _playerName;
    private List<Unit> _units;

    public Team(string playerName)
    {
        _playerName = playerName;
        _units = new List<Unit>();
    }
    
    public string GetPlayerName()
    {
        return _playerName;
    }
    
    public List<Unit> GetUnits()
    {
        return _units;
    }

    public void ConstructTeamFromFileLines(string[] teamLines, List<Character> characters)
    {
        foreach (var line in teamLines)
        {
            _units.Add(CreateUnitFromLine(line, characters));
        }
    }
    
    private Unit CreateUnitFromLine(string line, List<Character> characters)
    {
        var unitName = GetSkillsAndUnitNameFromLine(line, out var skills);
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

    private static string GetSkillsAndUnitNameFromLine(string line, out string[] skills)
    {
        string[] partsUnitLine = line.Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);
        string unitName = partsUnitLine[0].Trim();
        skills = partsUnitLine.Length > 1 ? partsUnitLine[1].Replace(")", "").Split(',') : Array.Empty<string>();
        return unitName;
    }

    public void RemoveDeadUnits(Unit unitPostCombat)
    {
        const int minimumHPofUnit = 0;
        if (unitPostCombat.HPCurrent <= minimumHPofUnit)
        {
            _units.Remove(unitPostCombat);
        }
    }

    public bool HasEqualUnits()
    {
        const int allowedNumberOfEqualUnits = 1;
        return _units.GroupBy(u => u.Name)
            .Any(g => g.Count() > allowedNumberOfEqualUnits);
    }
    
    private bool UnitHasValidSkills(Unit unit)
    {
        return unit.UnitHasValidAmountOfSkills() && !unit.UnitHasEqualSkills();
    }
    
    public bool TeamHasValidSkills()
    {
        return _units.All(UnitHasValidSkills);
    }
    
    public bool HasValidLength()
    {
        const int maxUnitsPerTeam = 3;
        const int minUnitsPerTeam = 1;
        return (_units.Count <= maxUnitsPerTeam && _units.Count >= minUnitsPerTeam);
    }

    public bool HasEnoughNumberOfUnits()
    {
        const int minAmountOfUnitsToBattle = 1;
        return _units.Count >= minAmountOfUnitsToBattle;
    }
}
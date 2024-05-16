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
            _units.Add(new UnitConstructorFromLine(line, characters).CreateUnitFromLine());
        }
    }
    
    public bool TeamHasValidSkills()
    {
        return _units.All(UnitHasValidSkills);
    }
    
    private bool UnitHasValidSkills(Unit unit)
    {
        return UnitHasValidAmountOfSkills(unit) && !UnitHasEqualSkills(unit);
    }
    
    private bool UnitHasEqualSkills(Unit unit)
    {
        const int maxAmountOfSkills = 2;
        if (unit.Skill.Length == maxAmountOfSkills)
        {
            if (unit.Skill[0] == unit.Skill[1])
            {
                return true;
            }
        }

        return false;
    }
    
    private bool UnitHasValidAmountOfSkills(Unit unit)
    {
        const int maxAmountOfSkills = 2;
        return unit.Skill.Length <= maxAmountOfSkills;
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
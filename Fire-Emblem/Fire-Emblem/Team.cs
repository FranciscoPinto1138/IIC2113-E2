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
        const int MAX_AMOUNT_OF_SKILLS = 2;
        if (unit.Skill.Length == MAX_AMOUNT_OF_SKILLS)
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
        const int MAX_AMOUNT_OF_SKILLS = 2;
        return unit.Skill.Length <= MAX_AMOUNT_OF_SKILLS;
    }
    
    public void RemoveDeadUnits(Unit unitPostCombat)
    {
        const int MIN_HP_OF_UNIT = 0;
        if (unitPostCombat.HPCurrent <= MIN_HP_OF_UNIT)
        {
            _units.Remove(unitPostCombat);
        }
    }

    public bool HasEqualUnits()
    {
        const int ALLOWED_NUMBER_OF_EQUAL_UNITS = 1;
        return _units.GroupBy(u => u.Name)
            .Any(g => g.Count() > ALLOWED_NUMBER_OF_EQUAL_UNITS);
    }
    
    public bool HasValidLength()
    {
        const int MAX_UNITS_PER_TEAM = 3;
        const int MIN_UNITS_PER_TEAM = 1;
        return (_units.Count <= MAX_UNITS_PER_TEAM && _units.Count >= MIN_UNITS_PER_TEAM);
    }

    public bool HasEnoughNumberOfUnits()
    {
        const int MIN_AMOUNT_OF_UNITS_TO_BATTLE = 1;
        return _units.Count >= MIN_AMOUNT_OF_UNITS_TO_BATTLE;
    }
}
namespace Fire_Emblem;

public class ValidTeamsChecker
{
    private Team _player1Team;
    private Team _player2Team;
    
    public ValidTeamsChecker(Team team1, Team team2)
    {
        _player1Team = team1;
        _player2Team = team2;
    }
    
    public bool IsValidTeam()
    {
        return !(!HasValidTeamLengths() || !TeamsHaveValidSkills() || TeamsHaveEqualUnits());
    }
    
    private bool HasValidTeamLengths()
    {
        return (HasValidLength(_player1Team) && HasValidLength(_player2Team));
    }

    private bool TeamsHaveValidSkills()
    {
        return (TeamHasValidSkills(_player1Team) && TeamHasValidSkills(_player2Team));
    }

    private bool TeamsHaveEqualUnits()
    {
        return HasEqualUnits(_player1Team) || HasEqualUnits(_player2Team);
    }

    private bool HasValidLength(Team team)
    {
        const int MAX_UNITS_PER_TEAM = 3;
        const int MIN_UNITS_PER_TEAM = 1;
        return (team.Units.Count <= MAX_UNITS_PER_TEAM && team.Units.Count >= MIN_UNITS_PER_TEAM);
    }
    
    private bool TeamHasValidSkills(Team team)
    {
        return team.Units.All(UnitHasValidSkills);
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

    private bool HasEqualUnits(Team team)
    {
        const int ALLOWED_NUMBER_OF_EQUAL_UNITS = 1;
        return team.Units.GroupBy(u => u.Name)
            .Any(g => g.Count() > ALLOWED_NUMBER_OF_EQUAL_UNITS);
    }
}
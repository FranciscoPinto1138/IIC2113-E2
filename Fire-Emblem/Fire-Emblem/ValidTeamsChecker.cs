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
    
    private bool HasValidTeamLengths()
    {
        return (_player1Team.HasValidLength() && _player2Team.HasValidLength());
    }

    private bool TeamsHaveValidSkills()
    {
        return (_player1Team.TeamHasValidSkills() && _player2Team.TeamHasValidSkills());
    }

    private bool TeamsHaveEqualUnits()
    {
        return _player1Team.HasEqualUnits() || _player2Team.HasEqualUnits();
    }
    
    public bool IsValidTeam()
    {
        return !(!HasValidTeamLengths() || !TeamsHaveValidSkills() || TeamsHaveEqualUnits());
    }
}
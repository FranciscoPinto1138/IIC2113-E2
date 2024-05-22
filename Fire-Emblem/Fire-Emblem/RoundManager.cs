namespace Fire_Emblem;

using Fire_Emblem_View;

public class RoundManager
{
    private Team _currentPlayerTeam;
    private Team _opponentPlayerTeam;
    private View _view;
    private Unit _currentPlayerSelectedUnit;
    private Unit _opponentSelectedUnit;
    private Unit[] _postCombatUnits;
    private UnitSelectionManager _unitSelectionManager;
    private int _round;

    public RoundManager(View view, Team player1Team, Team player2Team, int round)
    {
        _view = view;
        _unitSelectionManager = new UnitSelectionManager(_view);
        _currentPlayerTeam = player1Team;
        _opponentPlayerTeam = player2Team;
        _round = round;
    }
    
    public void DevelopRound()
    {
        AssignSelectedUnits();
        _view.ShowRoundStart(_round, _currentPlayerSelectedUnit.Name, _currentPlayerTeam.PlayerName);
        StartCombat();
        RemoveDeadUnitsFromTeams();
        SetUnitsLastRivalStats();
    }

    private void AssignSelectedUnits()
    {
        _currentPlayerSelectedUnit = _unitSelectionManager.SelectUnitOfPlayer(_currentPlayerTeam);
        _opponentSelectedUnit = _unitSelectionManager.SelectUnitOfPlayer(_opponentPlayerTeam);
    }
    
    private void StartCombat()
    {
        Combat combat = new Combat(_currentPlayerSelectedUnit, _opponentSelectedUnit, _view);
        _postCombatUnits = combat.ResolveCombat();
    }

    private void RemoveDeadUnitsFromTeams()
    {
        RemoveDeadUnits(_currentPlayerTeam, _postCombatUnits[0]);
        RemoveDeadUnits(_opponentPlayerTeam, _postCombatUnits[1]);
    }
    
    private void RemoveDeadUnits(Team team, Unit postCombatUnit)
    {
        const int MIN_HP_OF_UNIT = 0;
        if (postCombatUnit.HPCurrent <= MIN_HP_OF_UNIT)
        {
            team.Units.Remove(postCombatUnit);
        }
    }

    private void SetUnitsLastRivalStats()
    {
        _currentPlayerSelectedUnit.MostRecentRival = _opponentSelectedUnit.Name;
        _opponentSelectedUnit.MostRecentRival = _currentPlayerSelectedUnit.Name;
    }
}


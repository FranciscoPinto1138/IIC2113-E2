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
        ShowRoundStart();
        StartCombat();
        RemoveDeadUnitsFromTeams();
        SetUnitsLastRivalStats();
    }

    private void AssignSelectedUnits()
    {
        _currentPlayerSelectedUnit = _unitSelectionManager.SelectUnitOfPlayer(_currentPlayerTeam);
        _opponentSelectedUnit = _unitSelectionManager.SelectUnitOfPlayer(_opponentPlayerTeam);
    }

    private void ShowRoundStart()
    {
        _view.WriteLine($"Round {_round}: {_currentPlayerSelectedUnit.Name} ({_currentPlayerTeam.GetPlayerName()}) comienza");
    }

    private void StartCombat()
    {
        Combat combat = new Combat(_currentPlayerSelectedUnit, _opponentSelectedUnit, _view);
        _postCombatUnits = combat.ResolveCombat();
    }

    private void RemoveDeadUnitsFromTeams()
    {
        _currentPlayerTeam.RemoveDeadUnits(_postCombatUnits[0]);
        _opponentPlayerTeam.RemoveDeadUnits(_postCombatUnits[1]);
    }

    private void SetUnitsLastRivalStats()
    {
        _currentPlayerSelectedUnit.MostRecentRival = _opponentSelectedUnit.Name;
        _opponentSelectedUnit.MostRecentRival = _currentPlayerSelectedUnit.Name;
    }
}


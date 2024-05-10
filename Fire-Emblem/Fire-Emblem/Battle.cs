using Fire_Emblem_View;
namespace Fire_Emblem;

public class Battle
{
    private Team _player1Team;
    private Team _player2Team;
    private View _view;
    private Team _currentPlayerTeam;
    private Team _opponentPlayerTeam;
    private Unit _currentPlayerSelectedUnit;
    private Unit _opponentSelectedUnit;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    private Unit[] _postCombatUnits;
    private UnitSelectionManager _unitSelectionManager;
    private int _round;
    
    public Battle(Team player1Team, Team player2Team ,View view)
    {
        this._player1Team = player1Team;
        this._player2Team = player2Team;
        this._round = 1;
        this._firstPlayerOfRoundName = _player1Team.GetPlayerName();
        this._secondPlayerOfRoundName = _player2Team.GetPlayerName();
        _view = view;
        _unitSelectionManager = new UnitSelectionManager(_view);
    }
    
    private bool BattleHasWinner()
    {
        if (!_player1Team.HasEnoughNumberOfUnits())
        {
            _view.WriteLine($"{_player2Team.GetPlayerName()} ganó");
            return true;
        }
        if (!_player2Team.HasEnoughNumberOfUnits())
        {
            _view.WriteLine($"{_player1Team.GetPlayerName()} ganó");
            return true;
        }

        return false;
    }
    
    private void SetUnitsLastRivalStats()
    {
        _currentPlayerSelectedUnit.MostRecentRival = _opponentSelectedUnit.Name;
        _opponentSelectedUnit.MostRecentRival = _currentPlayerSelectedUnit.Name;
    }
    
    private void RemoveDeadUnitsFromTeams(Unit[] postCombatUnits)
    {
        _currentPlayerTeam.RemoveDeadUnits(postCombatUnits[0]);
        _opponentPlayerTeam.RemoveDeadUnits(postCombatUnits[1]);
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
        Combat combat = new Combat(_currentPlayerSelectedUnit, _opponentSelectedUnit, _currentPlayerTeam, _opponentPlayerTeam, _view);
        _postCombatUnits = combat.ResolveCombat();
    }
    
    private void DevelopRound()
    {
        AssignSelectedUnits();
        ShowRoundStart();
        StartCombat();
        RemoveDeadUnitsFromTeams(_postCombatUnits);
    }
    
    private void AssignPlayersRolesForRound()
    {
        _currentPlayerTeam = _firstPlayerOfRoundName == _player1Team.GetPlayerName() ? _player1Team : _player2Team;
        _opponentPlayerTeam = _secondPlayerOfRoundName == _player1Team.GetPlayerName() ? _player1Team : _player2Team;
    }
    
    private void SwapPlayersOrderForNextRound()
    {
        (_firstPlayerOfRoundName, _secondPlayerOfRoundName) = (_secondPlayerOfRoundName, _firstPlayerOfRoundName);
    }
    
    private void AdvanceToNextRound()
    {
        _round++;
    }
    
    public void DevelopBattle()
    {
        while (!BattleHasWinner())
        {
            AssignPlayersRolesForRound();
            DevelopRound();
            SetUnitsLastRivalStats();
            SwapPlayersOrderForNextRound();
            AdvanceToNextRound();
        }
    }
}
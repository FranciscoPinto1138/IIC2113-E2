using Fire_Emblem_View;
namespace Fire_Emblem;

public class Battle
{
    private Team _player1Team;
    private Team _player2Team;
    private View _view;
    private Team _currentPlayerTeam;
    private Team _opponentPlayerTeam;
    private string _firstPlayerOfRoundName;
    private string _secondPlayerOfRoundName;
    private UnitSelectionManager _unitSelectionManager;
    private int _round;
    
    public Battle(Team player1Team, Team player2Team ,View view)
    {
        this._player1Team = player1Team;
        this._player2Team = player2Team;
        const int INITIAL_ROUND = 1;
        this._round = INITIAL_ROUND;
        this._firstPlayerOfRoundName = _player1Team.PlayerName;
        this._secondPlayerOfRoundName = _player2Team.PlayerName;
        _view = view;
        _unitSelectionManager = new UnitSelectionManager(_view);
    }
    
    public void DevelopBattle()
    {
        while (!BattleHasWinner())
        {
            AssignPlayersRolesForRound();
            DevelopRound();
            SwapPlayersOrderForNextRound();
            AdvanceToNextRound();
        }
        ShowWinner();
    }
    
    private bool BattleHasWinner()
    {
        return !TeamHasEnoughNumberOfUnits(_player1Team) || !TeamHasEnoughNumberOfUnits(_player2Team);
    }
    
    private bool TeamHasEnoughNumberOfUnits(Team team)
    {
        const int MIN_AMOUNT_OF_UNITS_TO_BATTLE = 1;
        return team.Units.Count >= MIN_AMOUNT_OF_UNITS_TO_BATTLE;
    }

    private void ShowWinner()
    {
        if (!TeamHasEnoughNumberOfUnits(_player1Team))
        {
            _view.WriteLine($"{_player2Team.PlayerName} ganó");
        }
        else if (!TeamHasEnoughNumberOfUnits(_player2Team))
        {
            _view.WriteLine($"{_player1Team.PlayerName} ganó");
        }
    }
    
    private void AssignPlayersRolesForRound()
    {
        _currentPlayerTeam = _firstPlayerOfRoundName == _player1Team.PlayerName ? _player1Team : _player2Team;
        _opponentPlayerTeam = _secondPlayerOfRoundName == _player1Team.PlayerName ? _player1Team : _player2Team;
    }
    
    private void DevelopRound()
    {
        new RoundManager(_view, _currentPlayerTeam, _opponentPlayerTeam, _round).DevelopRound();
    }
    
    private void SwapPlayersOrderForNextRound()
    {
        (_firstPlayerOfRoundName, _secondPlayerOfRoundName) = (_secondPlayerOfRoundName, _firstPlayerOfRoundName);
    }
    
    private void AdvanceToNextRound()
    {
        _round++;
    }
}
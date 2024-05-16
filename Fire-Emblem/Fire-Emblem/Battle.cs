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
        this._round = 1;
        this._firstPlayerOfRoundName = _player1Team.GetPlayerName();
        this._secondPlayerOfRoundName = _player2Team.GetPlayerName();
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
    
    private void AssignPlayersRolesForRound()
    {
        _currentPlayerTeam = _firstPlayerOfRoundName == _player1Team.GetPlayerName() ? _player1Team : _player2Team;
        _opponentPlayerTeam = _secondPlayerOfRoundName == _player1Team.GetPlayerName() ? _player1Team : _player2Team;
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
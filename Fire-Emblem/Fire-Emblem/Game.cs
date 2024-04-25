using Fire_Emblem_View;
using System;
using System.IO;
using System . Text . Json ;

// Entrega 2
namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    private void StartBattle(Team[] teams)
    {
        Battle battle = new Battle(teams[0], teams[1], _view);
        battle.DevelopBattle();
    }
    
    public void Play()
    {
        TeamsLoader teamsLoader = new TeamsLoader(_view, _teamsFolder);
        Team[] teams = teamsLoader.LoadTeams();
        ValidTeamsChecker validTeamsChecker = new ValidTeamsChecker(teams[0], teams[1]);
        if (!validTeamsChecker.IsValidTeam())
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        else
        {
            StartBattle(teams);
        }
    }
}
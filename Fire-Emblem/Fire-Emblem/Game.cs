using Fire_Emblem_View;
using System;
using System.IO;
using System . Text . Json ;

// Entrega 3
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

    public void Play()
    {
        Team[] teams = GetTeamsFromFolder();
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
    
    private Team[] GetTeamsFromFolder()
    {
        TeamsLoader teamsLoader = new TeamsLoader(_view, _teamsFolder);
        return teamsLoader.LoadTeams();
    }
    
    private void StartBattle(Team[] teams)
    {
        Battle battle = new Battle(teams[0], teams[1], _view);
        battle.DevelopBattle();
    }
}
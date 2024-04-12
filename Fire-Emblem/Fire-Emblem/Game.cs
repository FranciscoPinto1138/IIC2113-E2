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

    private bool HasValidTeamLengths(Team player1Team, Team player2Team)
    {
        return (player1Team.HasValidLength() && player2Team.HasValidLength());
    }

    private bool TeamsHaveValidSkills(Team player1Team, Team player2Team)
    {
        return (player1Team.TeamHasValidSkills() && player2Team.TeamHasValidSkills());
    }

    private bool TeamsHaveEqualUnits(Team player1Team, Team player2Team)
    {
        return player1Team.HasEqualUnits() || player2Team.HasEqualUnits();
    }
    
    private bool IsValidTeam(Team player1Team, Team player2Team)
    {
        return !(!HasValidTeamLengths(player1Team, player2Team) || !TeamsHaveValidSkills(player1Team, player2Team) || TeamsHaveEqualUnits(player1Team, player2Team));
    }
    
    private void ShowAvailableTeamFiles(string[] teamFiles)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(teamFiles[i])}");
        }
    }

    private string GetSelectedTeamsFilePath()
    {
        string[] teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
        ShowAvailableTeamFiles(teamFiles);
        int selectedTeam = Convert.ToInt32(_view.ReadLine());
        return teamFiles[selectedTeam];
    }
    
    private List<Character> ProcessCharactersJson()
    {
        string myJson = File.ReadAllText("characters.json");
        List<Character> characters =  JsonSerializer . Deserialize<List<Character>>(myJson);
        return characters;
    }
    
    private Team[] ConstructTeams(TeamFile teamFile, List<Character> characters)
    {
        Team player1 = new Team("Player 1");
        Team player2 = new Team("Player 2");
    
        player1.ConstructTeamFromFileLines(teamFile.Team1Lines, characters);
        player2.ConstructTeamFromFileLines(teamFile.Team2Lines, characters);

        return new Team[] { player1, player2 };
    }
    
    private Team[] LoadTeams()
    {
        List<Character> characters = ProcessCharactersJson();
        TeamFile teamFile = new TeamFile(GetSelectedTeamsFilePath());
        return ConstructTeams(teamFile, characters);
    }

    private void StartBattle(Team[] teams)
    {
        Battle battle = new Battle(teams[0], teams[1], _view);
        battle.DevelopBattle();
    }
    
    public void Play()
    {
        Team[] teams = LoadTeams();
        if (!IsValidTeam(teams[0], teams[1]))
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        else
        {
            StartBattle(teams);
        }
    }
}
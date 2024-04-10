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

    private static bool HasValidTeamLengths(Team player1Team, Team player2Team)
    {
        return (player1Team.HasValidLength() && player2Team.HasValidLength());
    }

    private static bool TeamsHaveValidSkills(Team player1Team, Team player2Team)
    {
        return (player1Team.TeamHasValidSkills() && player2Team.TeamHasValidSkills());
    }

    private static bool TeamsHaveEqualUnits(Team player1Team, Team player2Team)
    {
        return player1Team.HasEqualUnits() || player2Team.HasEqualUnits();
    }
    private static bool IsValidTeam(Team player1Team, Team player2Team)
    {
        return !(!HasValidTeamLengths(player1Team, player2Team) || !TeamsHaveValidSkills(player1Team, player2Team) || TeamsHaveEqualUnits(player1Team, player2Team));
    }
    
    private Unit ChooseUnitOfPlayer(Team team)
    {
        ShowAvailableUnits(team);
        int playerChoice = Convert.ToInt32(_view.ReadLine());
        return team.Units[playerChoice];
    }
    
    private static void RemoveDeadUnitsFromTeams(Unit[] postCombatUnits, Team currentPlayerTeam, Team opponentPlayerTeam)
    {
        currentPlayerTeam.RemoveDeadUnits(postCombatUnits[0]);
        opponentPlayerTeam.RemoveDeadUnits(postCombatUnits[1]);
    }
    
    private void DevelopRound(Team currentPlayerTeam, Team opponentPlayerTeam, int round)
    {
        Unit currentPlayerSelectedUnit = ChooseUnitOfPlayer(currentPlayerTeam);
        Unit opponentSelectedUnit = ChooseUnitOfPlayer(opponentPlayerTeam);
    
        _view.WriteLine($"Round {round}: {currentPlayerSelectedUnit.Name} ({currentPlayerTeam.PlayerName}) comienza");
        Combat combat = new Combat(currentPlayerSelectedUnit, opponentSelectedUnit,  currentPlayerTeam, opponentPlayerTeam,_view);
        Unit[] postCombatUnits = combat.ResolveCombat();
        
        RemoveDeadUnitsFromTeams(postCombatUnits, currentPlayerTeam, opponentPlayerTeam);
    }
    
    private void ShowAvailableUnits(Team team)
    {
        const int minimumHPofUnit = 0;
        _view.WriteLine($"{team.PlayerName} selecciona una opción");
        for (int i = 0; i < team.Units.Count; i++)
        {
            if (team.Units[i].HPCurrent > minimumHPofUnit)
            {
                _view.WriteLine($"{i}: {team.Units[i].Name}");
            }
        }
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
    
    private static List<Character> ProcessCharactersJson()
    {
        string myJson = File.ReadAllText("characters.json");
        List<Character> characters =  JsonSerializer . Deserialize<List<Character>>(myJson);
        return characters;
    }
    
    private bool BattleHasWinner(Team player1, Team player2)
    {
        const int minAmountOfUnitsToBattle = 1;
        if (!(player1.Units.Count >= minAmountOfUnitsToBattle))
        {
            _view.WriteLine($"{player2.PlayerName} ganó");
            return true;
        }
        if (!(player2.Units.Count >= minAmountOfUnitsToBattle))
        {
            _view.WriteLine($"{player1.PlayerName} ganó");
            return true;
        }

        return false;
    }
    
    private void DevelopBattle(Team player1, Team player2)
    {
        string firstPlayer = player1.PlayerName;
        string secondPlayer = player2.PlayerName;
        int round = 1;
        while (!BattleHasWinner(player1, player2))
        {
            if (firstPlayer == player1.PlayerName)
            {
                DevelopRound(player1, player2, round);
            }
            else if (firstPlayer == player2.PlayerName)
            {
                DevelopRound(player2, player1, round);
            }
            firstPlayer = firstPlayer == player1.PlayerName ? player2.PlayerName : player1.PlayerName;
            secondPlayer = secondPlayer == player1.PlayerName ? player2.PlayerName : player1.PlayerName;
            round++;
        }
    }
    
    private static Team[] ConstructTeams(TeamFile teamFile, List<Character> characters)
    {
        Team player1 = new Team("Player 1");
        Team player2 = new Team("Player 2");
    
        player1.ConstructTeamFromFileLines(teamFile.Team1Lines, characters);
        player2.ConstructTeamFromFileLines(teamFile.Team2Lines, characters);

        return new Team[] { player1, player2 };
    }
    
    public void Play()
    {
        List<Character> characters = ProcessCharactersJson();
        TeamFile teamFile = new TeamFile(GetSelectedTeamsFilePath());
        Team[] teams = ConstructTeams(teamFile, characters);
        // Se chequea validez de equipo, informando al usuario en caso de ser inválido
        if (!IsValidTeam(teams[0], teams[1]))
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        // Si los equipos son válidos, se procede a la batalla
        else
        {
            DevelopBattle(teams[0], teams[1]);
        }
    }
}
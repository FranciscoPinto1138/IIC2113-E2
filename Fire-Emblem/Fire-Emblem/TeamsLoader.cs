namespace Fire_Emblem;
using Fire_Emblem_View;
using System . Text . Json ;

public class TeamsLoader
{
    private View _view;
    private string _teamsFolder;
    
    public TeamsLoader(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    
    public Team[] GetSelectedTeamsFromFile()
    {
        List<Character> characters = ProcessCharactersJson();
        TeamFile teamFile = new TeamFile(GetSelectedTeamsFilePath());
        return ConstructTeams(teamFile, characters);
    }
    
    private List<Character> ProcessCharactersJson()
    {
        string myJson = File.ReadAllText("characters.json");
        List<Character> characters =  JsonSerializer . Deserialize<List<Character>>(myJson);
        return characters;
    }
    
    private string GetSelectedTeamsFilePath()
    {
        string[] teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
        Array.Sort(teamFiles);
        ShowAvailableTeamFiles(teamFiles);
        int selectedTeam = Convert.ToInt32(_view.ReadLine());
        return teamFiles[selectedTeam];
    }
    
    private void ShowAvailableTeamFiles(string[] teamFiles)
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(teamFiles[i])}");
        }
    }
    
    private Team[] ConstructTeams(TeamFile teamFile, List<Character> characters)
    {
        string[][] teamsLines = teamFile.GetSplitTeamsLines();
        Team player1 = new Team("Player 1", teamsLines[0], characters);
        Team player2 = new Team("Player 2", teamsLines[1], characters);

        return new Team[] { player1, player2 };
    }
}
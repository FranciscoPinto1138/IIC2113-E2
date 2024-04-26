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
    
        player1.ConstructTeamFromFileLines(teamFile.GetTeam1Lines(), characters);
        player2.ConstructTeamFromFileLines(teamFile.GetTeam2Lines(), characters);

        return new Team[] { player1, player2 };
    }
    
    public Team[] LoadTeams()
    {
        List<Character> characters = ProcessCharactersJson();
        TeamFile teamFile = new TeamFile(GetSelectedTeamsFilePath());
        return ConstructTeams(teamFile, characters);
    }
}
using Fire_Emblem_View;
using System;
using System.IO;
using System . Text . Json ;

namespace Fire_Emblem;

public class TeamFile
{
    private string[] _fileLines;
    private string[] _team1Lines;
    private string[] _team2Lines;
    
    public TeamFile(string filePath)
    {
        _fileLines = File.ReadAllLines(filePath);
        _team1Lines = Array.Empty<string>();
        _team2Lines = Array.Empty<string>();
        this.SplitTeams();
    }
    
    public string[] GetTeam1Lines()
    {
        return _team1Lines;
    }
    
    public string[] GetTeam2Lines()
    {
        return _team2Lines;
    }

    private void SplitTeams()
    {
        int team1EndIndex = Array.IndexOf(_fileLines, "Player 2 Team");
        _team1Lines = new string[team1EndIndex - 1];
        Array.Copy(_fileLines, 1, _team1Lines, 0, team1EndIndex - 1);
        
        _team2Lines = new string[_fileLines.Length - team1EndIndex - 1];
        Array.Copy(_fileLines, team1EndIndex + 1, _team2Lines, 0, _fileLines.Length - team1EndIndex - 1);
    }
}
using Fire_Emblem_View;
using System;
using System.IO;
using System . Text . Json ;

namespace Fire_Emblem;

public class TeamFile
{
    private string[] _fileLines;
    public string[] Team1Lines;
    public string[] Team2Lines;
    
    public TeamFile(string filePath)
    {
        _fileLines = File.ReadAllLines(filePath);
        Team1Lines = Array.Empty<string>();
        Team2Lines = Array.Empty<string>();
        this.SplitTeams();
    }

    private void SplitTeams()
    {
        int team1EndIndex = Array.IndexOf(_fileLines, "Player 2 Team");
        Team1Lines = new string[team1EndIndex - 1];
        Array.Copy(_fileLines, 1, Team1Lines, 0, team1EndIndex - 1);
        
        Team2Lines = new string[_fileLines.Length - team1EndIndex - 1];
        Array.Copy(_fileLines, team1EndIndex + 1, Team2Lines, 0, _fileLines.Length - team1EndIndex - 1);
    }
}
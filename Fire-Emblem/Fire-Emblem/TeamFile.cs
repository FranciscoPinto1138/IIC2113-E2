using Fire_Emblem_View;
using System;
using System.IO;
using System . Text . Json ;

namespace Fire_Emblem;

public class TeamFile
{
    private string[] _fileLines;
    
    public TeamFile(string filePath)
    {
        _fileLines = File.ReadAllLines(filePath);
    }
    
    public string[][] GetSplitTeamsLines()
    {
        return SplitTeams();
    }

    private string[][] SplitTeams()
    {
        int team1EndIndex = Array.IndexOf(_fileLines, "Player 2 Team");
        string[] team1Lines = new string[team1EndIndex - 1];
        Array.Copy(_fileLines, 1, team1Lines, 0, team1EndIndex - 1);
        
       string[] team2Lines = new string[_fileLines.Length - team1EndIndex - 1];
        Array.Copy(_fileLines, team1EndIndex + 1, team2Lines, 0, 
            _fileLines.Length - team1EndIndex - 1);

        return new[] { team1Lines, team2Lines };
    }
}
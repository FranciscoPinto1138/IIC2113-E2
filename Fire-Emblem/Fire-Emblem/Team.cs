namespace Fire_Emblem;

public class Team
{
    public string PlayerName { get; }
    public List<Unit> Units { get; }

    public Team(string playerName)
    {
        PlayerName = playerName;
        Units = new List<Unit>();
    }

    public static Team LoadTeamFromFile(string filePath)
    {
        string[] fileLines = File.ReadAllLines(filePath);
        string playerName = fileLines[0];
        Team team = new Team(playerName);
        
        for (int i = 1; i < fileLines.Length; i++)
        {
            string line = fileLines[i];
            // Procesar la línea y agregar unidades al equipo
            // Código para procesar y agregar unidades omitido por simplicidad
        }

        return team;
    }

    public void RemoveDeadUnits()
    {
        Units.RemoveAll(unit => unit.HPCurrent <= 0);
    }
}
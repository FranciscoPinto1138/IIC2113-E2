using Fire_Emblem_View;
namespace Fire_Emblem;

public class UnitSelectionManager
{
    private View _view;
    public UnitSelectionManager(View view)
    {
        _view = view;
    }
    
    public Unit SelectUnitOfPlayer(Team team)
    {
        ShowAvailableUnits(team);
        int playerChoice = ReadPlayerSelectedUnit();
        return GetSelectedUnitOfPlayerTeam(playerChoice, team);
    }
    
    private void ShowAvailableUnits(Team team)
    {
        const int MIN_HP_OF_UNIT = 0;
        _view.WriteLine($"{team.PlayerName} selecciona una opción");
        for (int i = 0; i < team.Units.Count; i++)
        {
            if (team.Units[i].HPCurrent > MIN_HP_OF_UNIT)
            {
                _view.WriteLine($"{i}: {team.Units[i].Name}");
            }
        }
    }
    
    private int ReadPlayerSelectedUnit()
    {
        return Convert.ToInt32(_view.ReadLine());
    }
    
    private Unit GetSelectedUnitOfPlayerTeam(int playerChoice, Team team)
    {
        return team.Units[playerChoice];
    }
}
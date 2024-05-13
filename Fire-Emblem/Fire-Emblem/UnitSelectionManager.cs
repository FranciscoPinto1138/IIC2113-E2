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
        return GetSelectedUnitOfPlayerUnits(playerChoice, team);
    }
    
    private void ShowAvailableUnits(Team team)
    {
        const int minimumHPofUnit = 0;
        _view.WriteLine($"{team.GetPlayerName()} selecciona una opción");
        for (int i = 0; i < team.GetUnits().Count; i++)
        {
            if (team.GetUnits()[i].HPCurrent > minimumHPofUnit)
            {
                _view.WriteLine($"{i}: {team.GetUnits()[i].Name}");
            }
        }
    }
    
    private int ReadPlayerSelectedUnit()
    {
        return Convert.ToInt32(_view.ReadLine());
    }
    
    private Unit GetSelectedUnitOfPlayerUnits(int playerChoice, Team team)
    {
        return team.GetUnits()[playerChoice];
    }
}
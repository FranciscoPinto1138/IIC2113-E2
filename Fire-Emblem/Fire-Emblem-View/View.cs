namespace Fire_Emblem_View;

public class View
{
    private readonly AbstractView _view;

    public static View BuildConsoleView()
        => new View(new ConsoleView());
    
    public static View BuildTestingView(string pathTestScript)
        => new View(new TestingView(pathTestScript));

    public static View BuildManualTestingView(string pathTestScript)
        => new View(new ManualTestingView(pathTestScript));

    private View(AbstractView newView)
    {
        _view = newView;
    }

    public string ReadLine() => _view.ReadLine();

    public void WriteLine(string message)
    {
        _view.WriteLine(message);
    }
    
    public void ShowNotValidTeamFile()
    {
        _view.WriteLine("Archivo de equipos no válido");
    }
    
    public void ShowCombatResults(string attackUnitName, int attackUnitHP, string defenseUnitName, int defenseUnitHP)
    {
        _view.WriteLine($"{attackUnitName} ({attackUnitHP}) : {defenseUnitName} ({defenseUnitHP})");
    }
    
    public void ShowAppliedDamage(string attackUnitName, string defenseUnitName, int damage)
    {
        _view.WriteLine($"{attackUnitName} ataca a {defenseUnitName} con {damage} de daño");
    }
    
    public void ShowWinnerName(string winner)
    {
        _view.WriteLine($"{winner} ganó");
    }
    
    public void ShowRoundStart(int round, string currentPlayerSelectedUnitName, string currentPlayerTeamName)
    {
        _view.WriteLine($"Round {round}: {currentPlayerSelectedUnitName} ({currentPlayerTeamName}) comienza");
    }
    
    public string[] GetScript()
        => _view.GetScript();
}
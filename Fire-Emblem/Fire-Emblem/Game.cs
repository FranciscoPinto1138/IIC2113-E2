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

    public bool IsValidTeamLength(List<Unit> player1Team, List<Unit> player2Team)
    {
        if ((player1Team.Count == 0 || player1Team.Count > 3) || (player2Team.Count == 0 || player2Team.Count > 3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public bool HasValidSkills(List<Unit> player1Team, List<Unit> player2Team)
    {
        List<Unit>[] playerTeams = new List<Unit>[2];
        playerTeams[0] = player1Team;
        playerTeams[1] = player2Team;
        foreach (var team in playerTeams)
        {
            foreach (var unit in team)
            {
                if (unit.Skill.Length > 2)
                {
                    return false;
                }

                if (unit.Skill.Length == 2)
                {
                    if (unit.Skill[0] == unit.Skill[1])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    // Método para chequear validez de los equipos
    private bool IsValidTeam(List<Unit> player1Team, List<Unit> player2Team)
    {
        // Chequea si equipo es vacío o de más de tres unidades
        if (!IsValidTeamLength(player1Team, player2Team))
        {
            return false;
        }
        // Chequea que no haya unidades con más de dos habilidades y, si hay dos, que no sean iguales
        List<Unit>[] playerTeams = new List<Unit>[2];
        playerTeams[0] = player1Team;
        playerTeams[1] = player2Team;
        foreach (var team in playerTeams)
        {
            foreach (var unit in team)
            {
                if (unit.Skill.Length > 2)
                {
                    return false;
                }

                if (unit.Skill.Length == 2)
                {
                    if (unit.Skill[0] == unit.Skill[1])
                    {
                        return false;
                    }
                }
            }
        }
        
        // Chequea si hay dos unidades iguales en algún equipo agrupando por nombre y contando
        if ((player1Team.GroupBy(u => u.Name)
                .Any(g => g.Count() > 1)) || (player2Team.GroupBy(u => u.Name)
                .Any(g => g.Count() > 1)))
        {
            return false;
        }
        // Si ninguna de las condiciones que invalidan a un equipo se cumple, se retorna true
        return true;
    }

    private double[] WeaponTriangle(Unit attackUnit, Unit defenseUnit)
    {
        double WTBAttacker = 1.0;
        double WTBDefender = 1.0;
        if (attackUnit.Weapon == defenseUnit.Weapon || (attackUnit.Weapon == "Magic" || defenseUnit.Weapon == "Magic") || (attackUnit.Weapon == "Bow" || defenseUnit.Weapon == "Bow"))
        {
            // Misma arma o armas fuera del triángulo, no hay ventaja ni desventaja
            WTBAttacker = 1.0;
            WTBDefender = 1.0;
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        else if ((attackUnit.Weapon == "Sword" && defenseUnit.Weapon == "Axe") ||
                 (attackUnit.Weapon == "Axe" && defenseUnit.Weapon == "Lance") ||
                 (attackUnit.Weapon == "Lance" && defenseUnit.Weapon == "Sword"))
        {
            // Ventaja del atacante
            WTBAttacker = 1.2;
            WTBDefender = 0.8;
            _view.WriteLine($"{attackUnit.Name} ({attackUnit.Weapon}) tiene ventaja con respecto a {defenseUnit.Name} ({defenseUnit.Weapon})");
        }
        else if ((attackUnit.Weapon == "Axe" && defenseUnit.Weapon == "Sword") ||
                 (attackUnit.Weapon == "Lance" && defenseUnit.Weapon == "Axe") ||
                 (attackUnit.Weapon == "Sword" && defenseUnit.Weapon == "Lance"))
        {
            // Ventaja del defensor
            WTBAttacker = 0.8;
            WTBDefender = 1.2;
            _view.WriteLine($"{defenseUnit.Name} ({defenseUnit.Weapon}) tiene ventaja con respecto a {attackUnit.Name} ({attackUnit.Weapon})");
        }
        
        return new double[] { WTBAttacker, WTBDefender };
    }

    private Unit[] Combat(Unit attackUnit, Unit defenseUnit)
    {
        // Se determinan los WTB usando el método WeaponTriangle()
        double[] WTBs = WeaponTriangle(attackUnit, defenseUnit);
        double WTBAttacker = WTBs[0];
        double WTBDefender = WTBs[1];
        // Ataque
        // Se revisa si debe usarse Res o Def para el defensor
        int defenderDefOrRes = attackUnit.Weapon == "Magic" ? defenseUnit.Res : defenseUnit.Def;
        // Se calcula el daño y se resta al defensor
        int damageToDefender = Convert.ToInt32(Math.Max(0, Math.Floor((attackUnit.Atk * WTBAttacker) - defenderDefOrRes)));
        defenseUnit.HPCurrent = defenseUnit.HPCurrent - damageToDefender;
        _view.WriteLine($"{attackUnit.Name} ataca a {defenseUnit.Name} con {damageToDefender} de daño");
        // Si la unidad muere se termina el round
        if (defenseUnit.HPCurrent <= 0)
        {
            defenseUnit.HPCurrent = 0;
            _view.WriteLine($"{attackUnit.Name} ({attackUnit.HPCurrent}) : {defenseUnit.Name} ({defenseUnit.HPCurrent})");
            return [attackUnit, defenseUnit];
        }
        // Contraataque
        // Se revisa si debe usarse Res o Def para el atacante
        int attackerDefOrRes = defenseUnit.Weapon == "Magic" ? attackUnit.Res : attackUnit.Def;
        // Se calcula el daño y se resta al atacante
        int damageToAttacker = Convert.ToInt32(Math.Max(0, Math.Floor((defenseUnit.Atk * WTBDefender) - attackerDefOrRes)));
        attackUnit.HPCurrent = attackUnit.HPCurrent - damageToAttacker;
        _view.WriteLine($"{defenseUnit.Name} ataca a {attackUnit.Name} con {damageToAttacker} de daño");
        // Si la unidad muere se termina el round
        if (attackUnit.HPCurrent <= 0)
        {
            attackUnit.HPCurrent = 0;
            _view.WriteLine($"{attackUnit.Name} ({attackUnit.HPCurrent}) : {defenseUnit.Name} ({defenseUnit.HPCurrent})");
            return [attackUnit, defenseUnit];
        }
        // Follow-Up (si aplica)
        if (attackUnit.Spd - defenseUnit.Spd >= 5) // Atacante hace Follow-Up
        {
            defenseUnit.HPCurrent = defenseUnit.HPCurrent - damageToDefender;
            _view.WriteLine($"{attackUnit.Name} ataca a {defenseUnit.Name} con {damageToDefender} de daño");
            if (defenseUnit.HPCurrent <= 0)
            {
                defenseUnit.HPCurrent = 0;
                _view.WriteLine($"{attackUnit.Name} ({attackUnit.HPCurrent}) : {defenseUnit.Name} ({defenseUnit.HPCurrent})");
                return [attackUnit, defenseUnit];
            }
        }
        if (defenseUnit.Spd - attackUnit.Spd >= 5) // Defensor hace Follow-Up
        {
            attackUnit.HPCurrent = attackUnit.HPCurrent - damageToAttacker;
            _view.WriteLine($"{defenseUnit.Name} ataca a {attackUnit.Name} con {damageToAttacker} de daño");
            if (attackUnit.HPCurrent <= 0)
            {
                attackUnit.HPCurrent = 0;
                _view.WriteLine($"{attackUnit.Name} ({attackUnit.HPCurrent}) : {defenseUnit.Name} ({defenseUnit.HPCurrent})");
                return [attackUnit, defenseUnit];
            }
        }
        if (!((defenseUnit.Spd - attackUnit.Spd >= 5) || (attackUnit.Spd - defenseUnit.Spd >= 5))) // No ocurre Follow-Up
        {
          _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }

        _view.WriteLine($"{attackUnit.Name} ({attackUnit.HPCurrent}) : {defenseUnit.Name} ({defenseUnit.HPCurrent})");
        return [attackUnit, defenseUnit];
    }
    
    private void PlayerTurn(List<Unit> currentPlayerUnits, List<Unit> opponentUnits, string currentPlayer, string opponent, int round)
    {
        // Se despliegan las unidades disponibles del atacante
        ShowAvailableUnits(currentPlayerUnits, currentPlayer);

        // Se lee la opción seleccionada y se asigna la unidad del equipo del atacante
        int currentPlayerChoice = Convert.ToInt32(_view.ReadLine());
        Unit currentPlayerSelectedUnit = currentPlayerUnits[currentPlayerChoice];
    
        // Se despliegan las unidades disponibles del defensor
        ShowAvailableUnits(opponentUnits, opponent);

        // Se lee la opción seleccionada y se asigna la unidad del equipo del defensor
        int opponentChoice = Convert.ToInt32(_view.ReadLine());
        Unit opponentSelectedUnit = opponentUnits[opponentChoice];
    
        _view.WriteLine($"Round {round}: {currentPlayerSelectedUnit.Name} ({currentPlayer}) comienza");
        // Se entra al método Combat() para asignar daños
        Unit[] postCombatUnits = Combat(currentPlayerSelectedUnit, opponentSelectedUnit);
    
        RemoveDeadUnits(currentPlayerUnits, postCombatUnits[0]);
        RemoveDeadUnits(opponentUnits, postCombatUnits[1]);
    }
    
    private void ShowAvailableUnits(List<Unit> units, string player)
    {
        _view.WriteLine($"{player} selecciona una opción");
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].HPCurrent > 0)
            {
                _view.WriteLine($"{i}: {units[i].Name}");
            }
        }
    }
    
    private void RemoveDeadUnits(List<Unit> units, Unit unitToRemove)
    {
        if (unitToRemove.HPCurrent <= 0)
        {
            units.Remove(unitToRemove);
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
    
    private List<Character> ProcessCharactersJson()
    {
        string myJson = File.ReadAllText("characters.json");
        List<Character> characters =  JsonSerializer . Deserialize<List<Character>>(myJson);
        return characters;
    }
    
    private void DevelopBattle(Team player1, Team player2)
    {
        bool continueBattle = true;
        string firstPlayer = "Player 1";
        string secondPlayer = "Player 2";
        int round = 1;
        while (continueBattle)
        {
            if (firstPlayer == "Player 1")
            {
                PlayerTurn(player1.Units, player2.Units, firstPlayer, secondPlayer, round);
            }
            else if (firstPlayer == "Player 2")
            {
                PlayerTurn(player2.Units, player1.Units, firstPlayer, secondPlayer, round);
            }
            if (!player1.Units.Any())
            {
                _view.WriteLine("Player 2 ganó");
                continueBattle = false;
                break;
            }
            if (!player2.Units.Any())
            {
                _view.WriteLine("Player 1 ganó");
                continueBattle = false;
                break;
            }
            firstPlayer = firstPlayer == "Player 1" ? "Player 2" : "Player 1";
            secondPlayer = secondPlayer == "Player 1" ? "Player 2" : "Player 1";
            round++;
        }
    }
    
    private Team[] ConstructTeams(TeamFile teamFile, List<Character> characters)
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
        if (!IsValidTeam(teams[0].Units, teams[1].Units))
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
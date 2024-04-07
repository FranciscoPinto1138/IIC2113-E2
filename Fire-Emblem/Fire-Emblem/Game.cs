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
    // Método para chequear validez de los equipos
    private bool IsValidTeam(List<Unit> player1Team, List<Unit> player2Team)
    {
        // Chequea si equipo es vacío o de más de tres unidades
        if ((player1Team.Count == 0 || player1Team.Count > 3) || (player2Team.Count == 0 || player2Team.Count > 3))
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

    public void Play()
    {
        // Se buscan los archivos de equipos para que el usuario seleccione
        string[] teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
        _view.WriteLine("Elige un archivo para cargar los equipos");
        for (int i = 0; i < teamFiles.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(teamFiles[i])}");
        }
        // Se lee el input del usuario y se lee el archivo correspondiente
        int selectedTeam = Convert.ToInt32(_view.ReadLine());
        string[] fileLines = File.ReadAllLines(teamFiles[selectedTeam]);
        // Se obtienen los personajes del json
        string myJson = File.ReadAllText("characters.json");
        List<Character> characters =  JsonSerializer . Deserialize<List<Character>>(myJson);
        // Se crean las listas que guardarán las unidades de cada jugador
        List<Unit> player1Units = new List<Unit>();
        List<Unit> player2Units = new List<Unit>();
        string currentPlayer = fileLines[0];
        // El siguiente código lee las líneas con los personajes del archivo de equipo y los guarda como objetos de 
        // clase Unit en la lista de cada jugador. Para ello, se toma el nombre del personaje y se sacan los datos del
        // json "characters.json".
        for (int i = 0; i < fileLines.Length; i++)
        {
            if ((fileLines[i] != "Player 1 Team") && (fileLines[i] != "Player 2 Team"))
            {
                // Extraído de ChatGPT para separar correctamente cada línea que muestre a una unidad
                string[] parts = fileLines[i].Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);
                string unitName = parts[0].Trim();
                string[] skills = parts.Length > 1 ? parts[1].Replace(")", "").Split(',') : new string[0];
                // La siguiente línea encuentra el personaje en base a su nombre en el json leído
                Character character = characters.FirstOrDefault(c => c.Name.Trim() == unitName.Trim());
                if (currentPlayer == "Player 1 Team")
                {
                    player1Units.Add(new Unit(
                        character.Name,
                        character.Weapon,
                        character.Gender,
                        character.DeathQuote,
                        skills.Select(s => s.Trim()).ToArray(), // Trim each skill
                        Convert.ToInt32(character.HP),
                        Convert.ToInt32(character.Atk),
                        Convert.ToInt32(character.Spd),
                        Convert.ToInt32(character.Def),
                        Convert.ToInt32(character.Res)
                    ));
                }
                if (currentPlayer == "Player 2 Team")
                {
                    player2Units.Add(new Unit(
                        character.Name,
                        character.Weapon,
                        character.Gender,
                        character.DeathQuote,
                        skills.Select(s => s.Trim()).ToArray(), // Trim each skill
                        Convert.ToInt32(character.HP),
                        Convert.ToInt32(character.Atk),
                        Convert.ToInt32(character.Spd),
                        Convert.ToInt32(character.Def),
                        Convert.ToInt32(character.Res)
                    ));
                }
            }

            if (fileLines[i] == "Player 2 Team")
            {
                currentPlayer = "Player 2 Team";
            }
        }
        // Se chequea validez de equipo, informando al usuario en caso de ser inválido
        if (!IsValidTeam(player1Units, player2Units))
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        // Si los equipos son válidos, se procede a la batalla
        else
        {
            bool continueBattle = true;
            string firstPlayer = "Player 1";
            string secondPlayer = "Player 2";
            int round = 1;
            while (continueBattle)
            {
                //_view.WriteLine($"{firstPlayer} selecciona una opción");
                // En caso de que ataque (y empiece) el Player 1 esta ronda
                if (firstPlayer == "Player 1")
                {
                    PlayerTurn(player1Units, player2Units, firstPlayer, secondPlayer, round);
                }
                // Turno del jugador 2
                else if (firstPlayer == "Player 2")
                {
                    PlayerTurn(player2Units, player1Units, firstPlayer, secondPlayer, round);
                }
                // Se chequea que Player 1 tenga unidades vivas, de no ser el caso, se anuncia a Player 2 como ganador
                if (!player1Units.Any())
                {
                    _view.WriteLine("Player 2 ganó");
                    continueBattle = false;
                    break;
                }
                // Se chequea que Player 2 tenga unidades vivas, de no ser el caso, se anuncia a Player 1 como ganador
                if (!player2Units.Any())
                {
                    _view.WriteLine("Player 1 ganó");
                    continueBattle = false;
                    break;
                }
                // Se intercambia el orden de los jugadores para la siguiente ronda
                firstPlayer = firstPlayer == "Player 1" ? "Player 2" : "Player 1";
                secondPlayer = secondPlayer == "Player 1" ? "Player 2" : "Player 1";
                // Se avanza una ronda
                round++;
            }
        }
    }
}
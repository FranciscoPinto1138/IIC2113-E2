namespace Fire_Emblem;

public class UnitConstructorFromLine
{
    private string _line;
    private string[] _splitLine;
    private List<Character> _characters;
        
    public UnitConstructorFromLine(string line, List<Character> characters)
    {
        _line = line;
        _characters = characters;
    }
        
    public Unit CreateUnitFromLine()
    {
        SetSplitLine();
        string unitName = GetUnitNameFromSplitLine();
        string[] skills = GetSkillsFromSplitLine();
        Character character = _characters.FirstOrDefault(c => c.Name.Trim() == unitName.Trim());
        return new Unit(
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
        );
    }
    
    private void SetSplitLine()
    {
        _splitLine = _line.Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);;
    }
    
    private string GetUnitNameFromSplitLine()
    {
        return _splitLine[0].Trim();
    }
    
    private string[] GetSkillsFromSplitLine()
    {
        return _splitLine.Length > 1 ? 
            _splitLine[1].Replace(")", "").Split(',') : 
            Array.Empty<string>();
    }
}
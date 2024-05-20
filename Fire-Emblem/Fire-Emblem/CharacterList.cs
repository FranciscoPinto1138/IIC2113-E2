using System.Collections;
using System . Text . Json ;
namespace Fire_Emblem;

public class CharacterList : IEnumerable<Character>
{
    private readonly List<Character> _characters = new List<Character>();

    private void Add(Character character)
    {
        _characters.Add(character);
    }

    public IEnumerator<Character> GetEnumerator()
    {
        return _characters.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _characters.GetEnumerator();
    }

    public static CharacterList FromJson(string json)
    {
        var characters = JsonSerializer.Deserialize<List<Character>>(json);
        var characterList = new CharacterList();
        foreach (var character in characters)
        {
            characterList.Add(character);
        }
        return characterList;
    }
}

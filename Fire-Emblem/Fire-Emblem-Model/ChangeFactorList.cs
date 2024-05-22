using System.Collections;
namespace Fire_Emblem;

public class ChangeFactorList : IEnumerable<int>
{
    private readonly List<int> _changeFactors = new List<int>();

    public void Add(int changeFactor)
    {
        _changeFactors.Add(changeFactor);
    }
    
    public void Remove(int changeFactor)
    {
        _changeFactors.Remove(changeFactor);
    }

    public int Count => _changeFactors.Count;
    
    public int this[int index] => _changeFactors[index];

    public IEnumerator<int> GetEnumerator()
    {
        return _changeFactors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _changeFactors.GetEnumerator();
    }
}
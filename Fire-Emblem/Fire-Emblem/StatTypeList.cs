using System.Collections;
namespace Fire_Emblem;

public class StatTypeList : IEnumerable<StatType>
{
    private readonly List<StatType> _stats = new List<StatType>();

    public void Add(StatType stat)
    {
        _stats.Add(stat);
    }
    
    public void Remove(StatType stat)
    {
        _stats.Remove(stat);
    }

    public int Count => _stats.Count;
    
    public StatType this[int index] => _stats[index];

    public IEnumerator<StatType> GetEnumerator()
    {
        return _stats.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _stats.GetEnumerator();
    }
}
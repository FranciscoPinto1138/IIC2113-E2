using System;
using System.Collections;
namespace Fire_Emblem;

public class UnitList : IEnumerable<Unit>
{
    private readonly List<Unit> _units = new List<Unit>();

    public void Add(Unit unit)
    {
        _units.Add(unit);
    }
    
    public void Remove(Unit unit)
    {
        _units.Remove(unit);
    }

    public int Count => _units.Count;
    
    public Unit this[int index] => _units[index];

    public IEnumerator<Unit> GetEnumerator()
    {
        return _units.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _units.GetEnumerator();
    }
}
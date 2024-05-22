namespace Fire_Emblem;

public class ConditionList
{
    private List<Condition> _conditions;
    
    public ConditionList()
    {
        _conditions = new List<Condition>();
    }
    
    public List<Condition> GetConditions()
    {
        return _conditions;
    }
    
    public void Add(Condition condition)
    {
        _conditions.Add(condition);
    }

    public void Remove(Condition condition)
    {
        _conditions.Remove(condition);
    }

    public bool Contains(Condition condition)
    {
        return _conditions.Contains(condition);
    }
}
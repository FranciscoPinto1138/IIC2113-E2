namespace Fire_Emblem;

public class ConditionEffectPairList
{
    private List<ConditionEffectPair> _conditionEffectPairs;
    
    public ConditionEffectPairList()
    {
        _conditionEffectPairs = new List<ConditionEffectPair>();
    }
    
    public void AddConditionEffectPair(ConditionEffectPair conditionEffectPair)
    {
        _conditionEffectPairs.Add(conditionEffectPair);
    }
}
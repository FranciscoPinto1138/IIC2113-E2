using System.Collections;

namespace Fire_Emblem;

public class ConditionEffectPairList : IEnumerable<ConditionEffectPair>
{
    private readonly List<ConditionEffectPair> _conditionEffectPairs = new List<ConditionEffectPair>();

    public void Add(ConditionEffectPair conditionEffectPair)
    {
        _conditionEffectPairs.Add(conditionEffectPair);
    }

    public int Count => _conditionEffectPairs.Count;
    
    public void ApplyEffectsIfConditionsAreSatisfied(Unit attackUnit, Unit defenseUnit, int priority)
    {
        foreach (ConditionEffectPair pair in _conditionEffectPairs)
        {
            if (pair.HasPriority(priority))
            {
                pair.ApplyEffectIfConditionIsSatisfied(attackUnit, defenseUnit);
            }
        }
    }

    public IEnumerator<ConditionEffectPair> GetEnumerator()
    {
        return _conditionEffectPairs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _conditionEffectPairs.GetEnumerator();
    }
}
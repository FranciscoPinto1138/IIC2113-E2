using System;
using System.Collections;
namespace Fire_Emblem;

public class SkillList : IEnumerable<Skill>
{
    private readonly List<Skill> _skills = new List<Skill>();

    public void Add(Skill skill)
    {
        _skills.Add(skill);
    }

    public int Count => _skills.Count;
    
    public void AddConditionEffectPairs(Unit unit, Unit opponent, ConditionEffectPairList conditionEffectPairsList)
    {
        foreach (Skill skill in _skills)
        {
            foreach (ConditionEffectPair pair in skill.GetConditionEffectPairs(unit, opponent))
            {
                conditionEffectPairsList.Add(pair);
            }
        }
    }

    public IEnumerator<Skill> GetEnumerator()
    {
        return _skills.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _skills.GetEnumerator();
    }
}
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

    public IEnumerator<Skill> GetEnumerator()
    {
        return _skills.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _skills.GetEnumerator();
    }
}
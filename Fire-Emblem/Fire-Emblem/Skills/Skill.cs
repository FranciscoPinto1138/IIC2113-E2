namespace Fire_Emblem;

public abstract class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }

    public abstract void ApplyEffectIfConditionIsSatisfied(Unit unit, Unit opponent);
}

public class Bonus : Skill
{
    public override void ApplyEffectIfConditionIsSatisfied(Unit unit, Unit opponent)
    {
        throw new NotImplementedException();
    }
}
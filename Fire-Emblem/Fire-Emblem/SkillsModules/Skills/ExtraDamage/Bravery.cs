namespace Fire_Emblem;

public class Bravery : ExtraDamage
{
    public Bravery()
    {
        this.Name = "Bravery";
        this.Description = "La unidad inflige +5 de daño en cada ataque.";
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new NoCondition();
        var effectOnUnit = new IncreaseExtraDamage(5);
        return new ConditionEffectPair[] { new ConditionEffectPair(condition, effectOnUnit) };
    }
}
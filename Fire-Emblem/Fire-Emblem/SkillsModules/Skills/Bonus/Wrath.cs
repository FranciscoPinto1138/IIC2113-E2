namespace Fire_Emblem;

public class Wrath : Skill
{
    public Wrath()
    {
        this.Name = "Wrath";
        this.Description = "Al inicio del combate, por cada punto de HP que la unidad ha perdido, " +
                           "otorga Atk/Spd+1 durante el combate. (Max +30)";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(
            new NoCondition(), new IncreaseAtkSpdByLostHP()) 
        };
    }
}
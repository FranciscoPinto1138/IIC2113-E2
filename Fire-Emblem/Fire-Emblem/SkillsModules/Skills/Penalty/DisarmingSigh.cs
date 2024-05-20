namespace Fire_Emblem;

public class DisarmingSigh : Penalty
{
    public DisarmingSigh()
    {
        this.Name = "Disarming Sigh";
        this.Description = "Si el rival es hombre, inflige Atk-8 en ese rival durante el combate";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(new OpponentIsMaleCondition(), 
            new DecreaseOpponentStats([StatType.Atk], [8])) };
    }
}
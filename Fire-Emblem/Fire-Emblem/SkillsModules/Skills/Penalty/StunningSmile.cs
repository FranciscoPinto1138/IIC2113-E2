namespace Fire_Emblem;

public class StunningSmile : Penalty
{
    public StunningSmile()
    {
        this.Name = "Stunning Smile";
        this.Description = "Si el rival es hombre, inflige Spd-8 en ese rival durante el combate.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(new OpponentIsMaleCondition(), 
            new DecreaseOpponentStats([StatType.Spd], [8])) };
    }
}
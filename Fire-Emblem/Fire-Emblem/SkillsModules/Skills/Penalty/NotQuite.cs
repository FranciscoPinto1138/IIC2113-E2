namespace Fire_Emblem;

public class NotQuite : Skill
{
    public NotQuite()
    {
        this.Name = "Not *Quite*";
        this.Description = "Si el rival inicia el combate, inflige Atk-4 en ese rival durante el combate";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(new OpponentStartsCombatCondition(), 
            new DecreaseOpponentStats([StatType.Atk], [4])) };
    }
}
namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class Soulblade : Hybrid
{
    public Soulblade()
    {
        this.Name = "Soulblade";
        this.Description = "Al atacar con una espada, el daño es calculado usando el promedio entre Def y Res base del rival. (Considere este como un bonus o un penalty a los stats correspondientes).";
    }
    
    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        if (IsSwordAttack(unit, opponent))
        {
            int averageDefResOfRival = CalculateAverageDefRes(opponent);
            ApplyStatEffects(opponent, unit, averageDefResOfRival, StatType.Def);
            ApplyStatEffects(opponent, unit, averageDefResOfRival, StatType.Res);
        }
    }

    private bool IsSwordAttack(Unit unit, Unit opponent)
    {
        var condition = new UnitHasWeaponTypeCondition("Sword");
        return condition.IsConditionFulfilled(unit, opponent);
    }

    private int CalculateAverageDefRes(Unit opponent)
    {
        return Convert.ToInt32(Math.Floor((double)(opponent.Def + opponent.Res) / 2));
    }

    private void ApplyStatEffects(Unit opponent, Unit unit, int averageDefResOfRival, StatType statType)
    {
        int difference = averageDefResOfRival - (statType == StatType.Def ? opponent.Def : opponent.Res);
        if (difference != 0)
        {
            Effect effectOnOpponent = difference >= 0 ?
                new IncreaseStat(difference, statType) :
                new DecreaseStat(Math.Abs(difference), statType);
            effectOnOpponent.ApplyEffect(opponent, unit);
        }
    }
    
    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        var condition = new UnitHasWeaponTypeCondition("Sword");
        int averageDefResOfRival = CalculateAverageDefRes(opponent);
        int differenceDef = averageDefResOfRival - opponent.Def;
        int differenceRes = averageDefResOfRival - opponent.Res;
    
        List<ConditionEffectPair> pairs = new List<ConditionEffectPair>();
    
        if (differenceDef != 0)
        {
            Effect effectOnOpponentDef = differenceDef >= 0 ?
                new IncreaseOpponentStats([StatType.Def], [differenceDef]) :
                new DecreaseOpponentStats([StatType.Def], [Math.Abs(differenceDef)]);
            pairs.Add(new ConditionEffectPair(condition, effectOnOpponentDef));
        }
    
        if (differenceRes != 0)
        {
            Effect effectOnOpponentRes = differenceRes >= 0 ?
                new IncreaseOpponentStats([StatType.Res], [differenceRes]) :
                new DecreaseOpponentStats([StatType.Res], [Math.Abs(differenceRes)]);
            pairs.Add(new ConditionEffectPair(condition, effectOnOpponentRes));
        }
    
        return pairs.ToArray();
    }
}
namespace Fire_Emblem.SkillsModules.Skills.Hybrids;

public class LightAndDark : Hybrid
{
    public LightAndDark()
    {
        this.Name = "Light and Dark";
        this.Description = "Inflige Atk/Spd/Def/Res-5 en el rival, neutraliza los penaltis de la unidad " +
                           "y los bonus del rival.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { 
            new ConditionEffectPair(new NoCondition(), 
                new DecreaseOpponentStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res], [5, 5, 5, 5])),
            new ConditionEffectPair(new NoCondition(), 
                new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, 
                    StatType.Res, StatType.HP])),
            new ConditionEffectPair(new NoCondition(), 
                new NeutralizeOpponentBonusStats([StatType.Atk, StatType.Spd, StatType.Def, 
                    StatType.Res, StatType.HP]))
        };
    }
}
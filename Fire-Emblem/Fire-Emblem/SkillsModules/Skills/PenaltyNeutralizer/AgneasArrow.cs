namespace Fire_Emblem;

public class AgneasArrow : Skill
{
    public AgneasArrow()
    {
        this.Name = "Agnea's Arrow";
        this.Description = "Neutraliza los penaltis de la unidad.";
    }

    public override ConditionEffectPair[] GetConditionEffectPairs(Unit unit, Unit opponent)
    {
        return new ConditionEffectPair[] { new ConditionEffectPair(new NoCondition(), 
            new NeutralizePenaltyOnStats([StatType.Atk, StatType.Spd, StatType.Def, StatType.Res, StatType.HP])) 
        };
    }
}
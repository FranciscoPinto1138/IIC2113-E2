namespace Fire_Emblem;

public class WillToWin : Bonus
{
    public WillToWin(Unit unit, Unit opponent, string firstPlayerOfRoundName, string secondPlayerOfRoundName) : base(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName)
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
        this.firstPlayerOfRoundName = firstPlayerOfRoundName;
        this.secondPlayerOfRoundName = secondPlayerOfRoundName;
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitHPCondition(50, ThresholdType.Absolute, ComparisonType.LowerThanOrEqual);
        var effectOnUnit = new IncreaseAtk(8);
        if (condition.IsConditionFulfilled(unit, opponent, firstPlayerOfRoundName, secondPlayerOfRoundName))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
        }
    }
    
    public override void RemoveEffectsAfterCombat(Unit unit, Unit opponent)
    {
        var effectOnUnit = new IncreaseAtk(8);
        effectOnUnit.RemoveEffect(unit, opponent);
    }
}
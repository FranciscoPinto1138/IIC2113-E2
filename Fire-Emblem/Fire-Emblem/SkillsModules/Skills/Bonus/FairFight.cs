namespace Fire_Emblem;

public class FairFight : Bonus
{
    public FairFight(Unit unit, Unit opponent) : base(unit, opponent)
    {
        this.Name = "Fair Fight";
        this.Description = "Si la unidad inicia el combate, otorga Atk+6 a la unidad y al rival durante el combate.";
        this.unit = unit;
        this.opponent = opponent;
        //var conditions = new List<Condition> { new UnitStartsCombatCondition() };
        //var effects = new List<Effect> { new IncreaseAtk(6) };
    }

    public override void ApplyEffectsIfConditionsAreSatisfied(Unit unit, Unit opponent)
    {
        var condition = new UnitStartsCombatCondition();
        var effectOnUnit = new IncreaseStat(6, StatType.Atk);
        var effectOnOpponent = new IncreaseStat(6, StatType.Atk);
        if (condition.IsConditionFulfilled(unit, opponent))
        {
            effectOnUnit.ApplyEffect(unit, opponent);
            effectOnOpponent.ApplyEffect(opponent, unit);
        }
    }
}